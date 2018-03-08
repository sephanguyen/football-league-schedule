using System.Data.SqlClient;
using ApiConfiguration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Model.Model;
using Microsoft.AspNetCore.Mvc.Formatters;
using Repositories.ConnectionBase;
using Repositories.Entities;
using Microsoft.AspNetCore.Diagnostics;
using NLog.Extensions.Logging;
using Business.interfaces;
using Business.implements;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Business.Services;
using FootBallLeagueSchedule.Helpers;
using Newtonsoft.Json.Serialization;
using Business.implement_fake_data;
using System.Threading.Tasks;

namespace FootBallLeagueSchedule
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc(setupAction => {
                setupAction.ReturnHttpNotAcceptable = true;
                setupAction.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter());
            })
            .AddJsonOptions(options => {
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            });

            //services.AddScoped<IDbContext>(dbcontext => new DbContext(new SqlConnection(Configuration["AppSettings:StorageConnectionString"])));
            var databaseUse = DatabaseFactory.CreateDatabase(Configuration["AppSettings:ConcreteDatabaseName"], Configuration["AppSettings:StorageConnectionString"]);
            services.AddScoped<IDbContext>(dbcontext => new DbContext(databaseUse.CreateConnection()));
            services.AddSingleton<IApiConfigurationManager>(apiconfig => new ApiConfigurationManager(Configuration["AppSettings:EnviromentKey"]));
            //services.AddTransient<IFixtureBusiness, FixtureBusiness>();
            services.AddTransient<IFixtureBusiness, FixtureBusinessFake>();
            //services.AddTransient<IManagerTeamAndPlayerBusiness, ManagerTeamAndPlayerBusiness>();
            services.AddTransient<IManagerTeamAndPlayerBusiness, ManagerTeamAndPlayerBusinessFake>();
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            services.AddScoped<IUrlHelper, UrlHelper>(implementationFactory => {
                var actionContext = implementationFactory.GetService<IActionContextAccessor>().ActionContext;
                return new UrlHelper(actionContext);
            });
            services.AddTransient<IPropertyMappingService, PropertyMappingService>();
            services.AddTransient<ITypeHelperService, TypeHelperService>();
            services.AddHttpCacheHeaders(
                (expirationModelOptions) => {
                    expirationModelOptions.MaxAge = 600;
                },
                (validationModelOptions) =>
                {
                    validationModelOptions.AddMustRevalidate = true;
                }
            );

            services.AddResponseCaching();
            services.AddSwaggerGen(swagger =>
            {
                swagger.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info { Title = "Swagger For Backend" });
            });
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            loggerFactory.AddProvider(new NLogLoggerProvider());

            if(env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(appBuilder => {
                    appBuilder.Run(async context => {
                        var exceptionHandlerFeature = context.Features.Get<IExceptionHandlerFeature>();
                        if(exceptionHandlerFeature != null)
                        {
                            var logger = loggerFactory.CreateLogger("Global exception logger");
                            logger.LogError(500, 
                                exceptionHandlerFeature.Error,
                                exceptionHandlerFeature.Error.Message);
                        }
                        context.Response.StatusCode = 500;
                        await context.Response.WriteAsync("An unexpected fault happend. Try again later");
                    });
                });
            }
            //app.UseResponseCaching();
            //app.UseHttpCacheHeaders();
            app.UseCorsMiddleware();
            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Team, TeamModel>()
                    .ForMember(dest => dest.Players, opt => opt.MapFrom(src => src.Players));
                cfg.CreateMap<Player, PlayerModel>()
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
                    .ForMember(dest => dest.TeamName, opt => opt.MapFrom(src => src.Team.Name))
                    .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.DateOfBirth.GetCurrentAge()));
                cfg.CreateMap<Match, MatchModel>()
                    .ForMember(dest => dest.TotalScore, opt => opt.MapFrom(src => src.AwayScore + src.HomeScore))
                    .ForMember(dest => dest.Match_Date, opt => opt.MapFrom(src => src.Match_Date.ToString("dd/MM/yyyy")))
                    .ForMember(dest => dest.Match_Day, opt => opt.MapFrom(src => src.Match_Date.DayOfWeek.ToString()))
                    .ForMember(dest => dest.Match_Time, opt => opt.MapFrom(src => src.Match_Date.ToString("HH:mm")))
                    .ForMember(dest => dest.AwayTeamName, opt => opt.MapFrom(src => src.AwayTeam.Name))
                    .ForMember(dest => dest.HomeTeamName, opt => opt.MapFrom(src => src.HomeTeam.Name));
            });
        }

    }

    public class CorsMiddleware
    {
        private readonly RequestDelegate _next;

        public CorsMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            httpContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            httpContext.Response.Headers.Add("Access-Control-Allow-Credentials", "true");
            httpContext.Response.Headers.Add("Access-Control-Allow-Headers", "Content-Type, X-CSRF-Token, X-Requested-With, Accept, Accept-Version, Content-Length, Content-MD5, Date, X-Api-Version, X-File-Name");
            httpContext.Response.Headers.Add("Access-Control-Allow-Methods", "POST,GET,PUT,PATCH,DELETE,OPTIONS");
            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class CorsMiddlewareExtensions
    {
        public static IApplicationBuilder UseCorsMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CorsMiddleware>();
        }
    }
}
