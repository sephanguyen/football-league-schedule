using MicroOrm.Dapper.Repositories.DbContext;
using MicroOrm.Dapper.Repositories.SqlGenerator;
using Repositories.Repositories.implements;
using Repositories.Repositories.interfaces;
using System.Data;
using System.Data.SqlClient;

namespace Repositories.ConnectionBase
{
    public class DbContext : DapperDbContext, IDbContext
    {
        private IPlayersRepository _playerRepository;
        private ITeamsRepository _teamRepository;
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

        public IPlayersRepository PlayerRepository => _playerRepository ?? (_playerRepository = new PlayersRepository(Connection, _config));

        public ITeamsRepository TeamRepository => _teamRepository ?? (_teamRepository = new TeamsRepository(Connection, _config));
    }
}
