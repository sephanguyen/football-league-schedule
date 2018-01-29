﻿using ApiConfiguration;
using Business.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace FootBallLeagueSchedule.Controllers
{
    public class BaseController : Controller
    {
        protected readonly IApiConfigurationManager ApiConfigurationManager;
        protected readonly ILogger Logger;
        protected readonly IUrlHelper UrlHelper;
        protected readonly IPropertyMappingService PropertyMappingService;
        public BaseController(IApiConfigurationManager apiConfigurationManager,
                             ILogger<BaseController> logger,
                             IUrlHelper urlHelper,
                             IPropertyMappingService propertyMappingService)
        {
            ApiConfigurationManager = apiConfigurationManager ?? throw new ArgumentException("apiConfigurationManager is null");
            Logger = logger ?? throw new ArgumentException("logger is null");
            UrlHelper = urlHelper ?? throw new ArgumentException("urlHelper is null");
            PropertyMappingService = propertyMappingService ?? throw new ArgumentException("propertyMappingService is null");
        }
    }
}
