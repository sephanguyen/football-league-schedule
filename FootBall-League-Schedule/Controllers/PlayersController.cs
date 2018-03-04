
using ApiConfiguration;
using AutoMapper;
using Business.interfaces;
using Business.Services;
using FootBallLeagueSchedule.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FootBallLeagueSchedule.Controllers
{
    [Route("api/teams/{teamId}/players")]
    public class PlayersController : BaseController
    {
        private readonly IManagerTeamAndPlayerBusiness _managerTeamAndPlayerBusiness;

        public PlayersController(IManagerTeamAndPlayerBusiness managerTeamAndPlayerBusiness, IApiConfigurationManager apiConfigurationManager, ILogger<BaseController> logger, IUrlHelper urlHelper, IPropertyMappingService propertyMappingService, ITypeHelperService typeHelperService) : base(apiConfigurationManager, logger, urlHelper, propertyMappingService, typeHelperService)
        {
            _managerTeamAndPlayerBusiness = managerTeamAndPlayerBusiness ?? throw new ArgumentException("managerTeamAndPlayerBusiness is null");
        }

        [HttpGet()]
        public async Task<IActionResult> GetPlayersForTeam(int teamId)
        {
            var playersForTeamFromBus = await _managerTeamAndPlayerBusiness.GetPlayersForTeam(teamId);
            var playersForTeam = Mapper.Map<IEnumerable<PlayerModel>>(playersForTeamFromBus);
            return Ok(playersForTeam);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPlayerForTeam(int teamId, int id)
        {
            var playerForTeamFromBus = await _managerTeamAndPlayerBusiness.GetPlayerForTeam(teamId, id);
            var playersForTeam = Mapper.Map<PlayerModel>(playerForTeamFromBus);
            return Ok(playersForTeam);
        }
    }
}
