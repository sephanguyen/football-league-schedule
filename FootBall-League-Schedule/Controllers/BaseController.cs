using ApiConfiguration;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FootBallLeagueSchedule.Controllers
{
    public class BaseController : Controller
    {
        protected readonly IApiConfigurationManager ApiConfigurationManager;
        public BaseController(IApiConfigurationManager apiConfigurationManager)
        {
            ApiConfigurationManager = apiConfigurationManager ?? throw new ArgumentException("apiConfigurationManager is null");
        }
    }
}
