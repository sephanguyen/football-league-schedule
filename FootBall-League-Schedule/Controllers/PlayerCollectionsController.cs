using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApiConfiguration;
using AutoMapper;
using Business.interfaces;
using Business.Services;
using FootBallLeagueSchedule.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model.PostParametersModels.TeamPostParameter;
using Repositories.Entities;

namespace FootBallLeagueSchedule.Controllers
{
    [Route("api/teams/{teamId}/playerscollections")]
    public class PlayerCollectionsController : BaseController
    {
        private readonly IManagerTeamAndPlayerBusiness _managerTeamAndPlayerBusiness;

        public PlayerCollectionsController(IManagerTeamAndPlayerBusiness managerTeamAndPlayerBusiness, IApiConfigurationManager apiConfigurationManager, ILogger<BaseController> logger, IUrlHelper urlHelper, IPropertyMappingService propertyMappingService, ITypeHelperService typeHelperService) : base(apiConfigurationManager, logger, urlHelper, propertyMappingService, typeHelperService)
        {
             _managerTeamAndPlayerBusiness = managerTeamAndPlayerBusiness ?? throw new ArgumentException("managerTeamAndPlayerBusiness is null");

        }

        [HttpPost(Name="CreatePlayersForTeam")]
        public async Task<IActionResult> CreatePlayersForTeam(int teamId, IEnumerable<PlayerCreatePostParameterModel> playersCreateModel)
        {
            if(playersCreateModel == null)
            {
                return BadRequest();
            }
            var playersEntity = Mapper.Map<IEnumerable<Player>>(playersCreateModel);
            if((await _managerTeamAndPlayerBusiness.AddPlayers(teamId, playersEntity)) < 0)
            {
                throw new Exception("Creating a player failed on save.");
            }
            return CreatedAtRoute("GetTeam", new { id = teamId});
        }

        
    }
}