using ApiConfiguration;
using Business.Services;
using Microsoft.Extensions.Logging;
using Repositories.ConnectionBase;
using System;

namespace Business.implements
{
    public class BusinessBase
    {
        protected readonly IDbContext DbContext;
        protected readonly ILogger Logger;
        protected readonly IPropertyMappingService PropertyMappingService;

        public BusinessBase(IDbContext dbContext,
                             ILogger<BusinessBase> logger,
                             IPropertyMappingService propertyMappingService)
        {
            DbContext = dbContext ?? throw new ArgumentException("dbContext is null");
            Logger = logger ?? throw new ArgumentException("logger is null");
            PropertyMappingService = propertyMappingService ?? throw new ArgumentException("propertyMappingService is null");
        }
    }
}
