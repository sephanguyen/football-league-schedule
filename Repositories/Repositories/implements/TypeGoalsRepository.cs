using System.Data;
using MicroOrm.Dapper.Repositories.SqlGenerator;
using Repositories.Entities;
using Repositories.interfaces;
using Repositories.Repositories.implements;

namespace Repositories.implements
{
    public class TypeGoalsRepository : RepositoryBase<TypeGoal>, ITypeGoalsRepository
    {
        public TypeGoalsRepository(IDbConnection connection, SqlGeneratorConfig sqlConnector) : base(connection, sqlConnector)
        {
        }
    }
}