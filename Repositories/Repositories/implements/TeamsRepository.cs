using MicroOrm.Dapper.Repositories.SqlGenerator;
using Repositories.Entities;
using Repositories.Repositories.interfaces;
using System.Data;

namespace Repositories.Repositories.implements
{
    public class TeamsRepository : RepositoryBase<Team>, ITeamsRepository
    {
        public TeamsRepository(IDbConnection connection, SqlGeneratorConfig sqlConnector) : base(connection, sqlConnector)
        {
        }
    }
}
