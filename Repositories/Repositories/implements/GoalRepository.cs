using System.Data;
using MicroOrm.Dapper.Repositories.SqlGenerator;
using Repositories.Entities;
using Repositories.interfaces;
using Repositories.Repositories.implements;

namespace Repositories.implements
{
    public class GoalRepository : RepositoryBase<Goal>, IGoalRepository
    {
        public GoalRepository(IDbConnection connection, SqlGeneratorConfig sqlConnector) : base(connection, sqlConnector)
        {
        }
    }
}