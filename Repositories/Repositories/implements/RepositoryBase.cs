using MicroOrm.Dapper.Repositories;
using MicroOrm.Dapper.Repositories.SqlGenerator;
using System.Data;

namespace Repositories.Repositories.implements
{
    public abstract class RepositoryBase<T> : DapperRepository<T> where T : class
    {
        public RepositoryBase(IDbConnection connection, SqlGeneratorConfig sqlConnector) : base(connection, sqlConnector)
        {
        }
        
    }
}
