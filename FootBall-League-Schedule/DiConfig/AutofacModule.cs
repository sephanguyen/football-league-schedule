using Autofac;
using Business.implements;
using Business.interfaces;
using Microsoft.Extensions.Configuration;
using Repositories.ConnectionBase;
using Repositories.Repositories.implements;
using Repositories.Repositories.interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace FootBallLeagueSchedule.DIConfig
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<TeamPlayerBusiness>()
                .As<ITeamPlayerBusiness>()
                .InstancePerLifetimeScope();

            // The generic ILogger<TCategoryName> service was added to the ServiceCollection by ASP.NET Core.
            // It was then registered with Autofac using the Populate method in ConfigureServices.
            //builder.RegisterType<PlayersRepository>()
            //    .As<IPlayersRepository>()
            //    .InstancePerLifetimeScope();
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json.config", optional: true)
            .Build();
            builder.RegisterType<DbContext>()
                .As<IDbContext>().WithParameter(
                        "connection",
                        new SqlConnection("Server=72bb22f1-a816-43c8-a3d0-a860006240a7.sqlserver.sequelizer.com;Database=db72bb22f1a81643c8a3d0a860006240a7;User ID=nqaquqlqjupnrmtn;Password=nSFqqWkZUP3yUPzxBSsS8nLQ4AMeC4y8Y2HShogRCi2iTd3Nvoe7jcFafYvWifvY;"))
                .InstancePerLifetimeScope();
            //builder.Register(c => new SqlConnection("MyConnectionStringHere"))
            //    .As<IDbConnection>().InstancePerLifetimeScope();


        }
    }
}
