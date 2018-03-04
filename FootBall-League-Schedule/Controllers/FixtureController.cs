
using ApiConfiguration;
using AutoMapper;
using Business.interfaces;
using Business.Services;
using FootBallLeagueSchedule.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model.MatchPostParameter.PostParametersModels;
using Model.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FootBallLeagueSchedule.Controllers
{
    [Route("api/fixture")]
    public class FixtureController : BaseController
    {
        private readonly IFixtureBusiness _fixtireBusiness;

        public FixtureController(IFixtureBusiness fixtureBusiness, IApiConfigurationManager apiConfigurationManager, ILogger<BaseController> logger, IUrlHelper urlHelper, IPropertyMappingService propertyMappingService, ITypeHelperService typeHelperService) : base(apiConfigurationManager, logger, urlHelper, propertyMappingService, typeHelperService)
        {
            _fixtireBusiness = fixtureBusiness ?? throw new ArgumentException("managerTeamAndPlayerBusiness is null");

        }
        [HttpGet(Name = "GetFixtureList")]
        public async Task<IActionResult> GetFixtureList(ListFixturePostParametersModel listFixturePostParameters)
        {
            var fixtureListFromBus = await _fixtireBusiness.GetListFixture(listFixturePostParameters);
            var fixtureList = Mapper.Map<IEnumerable<MatchModel>>(fixtureListFromBus);
            return Ok(fixtureList);
        }
    }
}
