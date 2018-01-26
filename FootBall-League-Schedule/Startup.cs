using System;
using System.Data.SqlClient;
using ApiConfiguration;
using Autofac;
using FootBallLeagueSchedule.DIConfig;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Repositories.ConnectionBase;

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
            services.AddMvc();
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

            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
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
