
using System.Data;
using MicroOrm.Dapper.Repositories.SqlGenerator;
using Model.Model;
using Repositories.Entities;
using Repositories.Repositories.interfaces;
using System;
namespace Repositories.Repositories.implements
{
    public class PlayersRepository : RepositoryBase<Player>, IPlayersRepository
    {
        public PlayersRepository(IDbConnection connection, SqlGeneratorConfig sqlConnector) :  base(connection, sqlConnector)
        {
        }

        
    }
}
