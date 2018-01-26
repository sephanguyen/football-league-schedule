using ApiConfiguration;
using Repositories.ConnectionBase;
using System;

namespace Business.implements
{
    public class BusinessBase
    {
        protected readonly IDbContext DbContext;
        public BusinessBase(IDbContext dbContext)
        {
            DbContext = dbContext ?? throw new ArgumentException("dbContext is null");
        }
    }
}
