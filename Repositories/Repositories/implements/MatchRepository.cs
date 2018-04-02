using System.Data;
using MicroOrm.Dapper.Repositories.SqlGenerator;
using Repositories.Entities;
using Repositories.interfaces;
using Repositories.Repositories.implements;

namespace Repositories.implements
{
    public class MatchRepository : RepositoryBase<Match>, IMatchRepository
    {
        public MatchRepository(IDbConnection connection, SqlGeneratorConfig sqlConnector) : base(connection, sqlConnector)
        {
        }
    }
}