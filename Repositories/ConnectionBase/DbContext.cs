using MicroOrm.Dapper.Repositories.DbContext;
using MicroOrm.Dapper.Repositories.SqlGenerator;
using Repositories.Repositories.implements;
using Repositories.Repositories.interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Repositories.ConnectionBase
{
    public class DbContext : DapperDbContext, IDbContext
    {
        private IPlayersRepository _playersRepository;
        private SqlGeneratorConfig _config;
        public DbContext(IDbConnection connection) : base(connection)
        {
            if (connection != null)
            {
                if (connection is SqlConnection)
                {
                    _config = new SqlGeneratorConfig
                    {
                        SqlConnector = ESqlConnector.MSSQL,
                        UseQuotationMarks = true
                    };
                }
            }
        }

        public IPlayersRepository PlayerRepository => _playersRepository ?? (_playersRepository = new PlayersRepository(Connection, _config));
    }
}
