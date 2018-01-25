using MicroOrm.Dapper.Repositories;
using System.Data;

namespace Repositories.Repositories.implements
{
    public abstract class RepositoryBase<T> : DapperRepository<T> where T : class
    {
        public RepositoryBase(IDbConnection connection) : base(connection)
        {
        }
    }
}
