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
    public class AutofacModuleService : Module
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
            //builder.Register(c => new SqlConnection("MyConnectionStringHere"))
            //    .As<IDbConnection>().InstancePerLifetimeScope();


        }
    }
}
