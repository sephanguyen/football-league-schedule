
using ApiConfiguration;
using AutoMapper;
using Business.interfaces;
using Business.Services;
using FootBallLeagueSchedule.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model.Model;
using Model.PostParametersModels.TeamPostParameter;
using Repositories.Entities;
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

        [HttpPost(Name="CreatePlayer")]
        public async Task<IActionResult> CreatePlayerForTeam(int teamId, PlayerCreatePostParameterModel playerCreateModel)
        {
            if(playerCreateModel == null)
            {
                return BadRequest();
            }
            var playerEntity = Mapper.Map<Player>(playerCreateModel);
            if(!(await _managerTeamAndPlayerBusiness.AddPlayer(playerEntity)))
            {
                throw new Exception("Creating a player failed on save.");
            }
            var playerToReturn = Mapper.Map<TeamModel>(playerEntity);
            return CreatedAtRoute("GetTeam", new { id = playerEntity.TeamId }, playerToReturn);
        }

        [HttpPut(Name="UpdatePlayer")]
        public async Task<IActionResult> UpdatePlayerForTeam(int teamId, PlayerUpdatePostParameterModel playerCreateModel)
        {
            if(playerCreateModel == null)
            {
                return BadRequest();
            }
            var playerEntity = Mapper.Map<Player>(playerCreateModel);
            if(!(await _managerTeamAndPlayerBusiness.UpdatePlayer(playerEntity)))
            {
                throw new Exception("Update a player failed on save.");
            }
            var playerToReturn = Mapper.Map<TeamModel>(playerEntity);
            return CreatedAtRoute("GetTeam", new { id = playerEntity.TeamId }, playerToReturn);
        }
        
        [HttpPut(Name="UpdatePlayers")]
        public async Task<IActionResult> UpdatePlayersForTeam(IEnumerable<PlayerUpdatePostParameterModel> playersCreateModel)
        {
            if(playersCreateModel == null)
            {
                return BadRequest();
            }
            var playersEntity = Mapper.Map<IEnumerable<Player>>(playersCreateModel);
            if(!(await _managerTeamAndPlayerBusiness.UpdatePlayers(playersEntity)))
            {
                throw new Exception("Creating a player failed on save.");
            }
            return Ok("Updated success!");
        }
    }
}
