using MicroOrm.Dapper.Repositories.DbContext;
using MicroOrm.Dapper.Repositories.SqlGenerator;
using Repositories.Repositories.implements;
using Repositories.Repositories.interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Repositories.ConnectionBase
{
    public class DbContext : DapperDbContext, IDbContext
    {
        private IPlayersRepository _playersRepository;

        public DbContext(IDbConnection connection) : base(connection)
        {
        }

        public IPlayersRepository PlayerRepository => _playersRepository ?? (_playersRepository = new PlayersRepository(Connection));
    }
}
