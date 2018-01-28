using System.Data.SqlClient;
using ApiConfiguration;
using Autofac;
using FootBallLeagueSchedule.DIConfig;
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
            });
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

            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Player, PlayerModel>()
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.NamePlayer));
            });
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
           
            builder.RegisterModule(new AutofacModuleService());
            builder.RegisterType<DbContext>()
                .As<IDbContext>().WithParameter(
                        "connection",
                        new SqlConnection(Configuration["AppSettings:StorageConnectionString"]))
                .InstancePerLifetimeScope();
            builder.RegisterType<ApiConfigurationManager>().As<IApiConfigurationManager>()
                .WithParameter("env", Configuration["AppSettings:EnviromentKey"])
                .SingleInstance();
        }


    }
}
