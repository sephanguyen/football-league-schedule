using MicroOrm.Dapper.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Repositories.Repositories.implements
{
    public abstract class RepositoryBase<T> : DapperRepository<T> where T : class
    {
        public RepositoryBase(IDbConnection connection) : base(connection)
        {
        }
    }
}
