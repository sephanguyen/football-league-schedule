using ApiConfiguration;
using AutoMapper;
using Business.interfaces;
using Business.Services;
using FootBallLeagueSchedule.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model.Model;
using Model.PostParametersModels;
using Model.PostParametersModels.TeamPostParameter;
using Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FootBallLeagueSchedule.Controllers
{
    [Route("api/teams")]
    public class TeamsController : BaseController
    {
        private readonly IManagerTeamAndPlayerBusiness _managerTeamAndPlayerBusiness;

        public TeamsController(IManagerTeamAndPlayerBusiness managerTeamAndPlayerBusiness,
                            IApiConfigurationManager apiConfigurationManager,
                            ILogger<BaseController> logger,
                            IUrlHelper urlHelper,
                            IPropertyMappingService propertyMappingService,
                            ITypeHelperService typeHelperService) : base(apiConfigurationManager, logger, urlHelper, propertyMappingService, typeHelperService)
        {
            _managerTeamAndPlayerBusiness = managerTeamAndPlayerBusiness ?? throw new ArgumentException("managerTeamAndPlayerBusiness is null");
        }

        [HttpGet(Name = "GetTeams")]
        public async Task<IActionResult> GetTeams(ListTeamPostParameterModel teamPostParameterModel)
        {
            if (!PropertyMappingService.ValidMappingExistsFor<TeamModel, Team>(teamPostParameterModel.OrderBy))
            {
                return BadRequest();
            }
            if (!TypeHelperService.TypeHasProperties<TeamModel>(teamPostParameterModel.Fields))
            {
                return BadRequest();
            }
            var teamsFromBus = await _managerTeamAndPlayerBusiness.GetTeams(teamPostParameterModel);
            var previousPageLink = teamsFromBus.HasPrevious ? CreatePlayerResourceUri("GetTeams", teamPostParameterModel, ResourceUriType.PreviousPage) : null;
            var nextPageLink = teamsFromBus.HasNext ? CreatePlayerResourceUri("GetTeams", teamPostParameterModel, ResourceUriType.NextPage) : null;
            var paginationMetadata = new
            {
                totalCount = teamsFromBus.Count,
                pageSize = teamsFromBus.PageSize,
                currentPage = teamsFromBus.CurrentPage,
                totalPages = teamsFromBus.TotalPages,
                previousPageLink = previousPageLink,
                nextPageLink = nextPageLink
            };

            Response.Headers.Add("X-Pagination",
                Newtonsoft.Json.JsonConvert.SerializeObject(paginationMetadata));

            var teams = Mapper.Map<IEnumerable<TeamModel>>(teamsFromBus);
            return Ok(teams.ShapeData(teamPostParameterModel.Fields));
        }
        [HttpGet("{id}", Name = "GetTeam")]
        public async Task<IActionResult> GetTeam(int id, [FromQuery] string fields)
        {
            if (!TypeHelperService.TypeHasProperties<TeamModel>(fields))
            {
                return BadRequest();
            }
            var teamFromRepo = await _managerTeamAndPlayerBusiness.GetTeam(id);
            if (teamFromRepo == null)
            {
                return NotFound();
            }
            var team = Mapper.Map<TeamModel>(teamFromRepo);
            return Ok(team.ShapData(fields));
        }


        [HttpPost(Name = "CreateTeam")]
        public async Task<IActionResult> CreateTeam([FromBody] TeamCreatePostParameterModel model)
        {
            if(model == null)
            {
                return BadRequest();
            }
            var teamEntity = Mapper.Map<Team>(model);
            if(!(await _managerTeamAndPlayerBusiness.AddTeam(teamEntity)))
            {
                throw new Exception("Creating an team failed on save.");
            }
            var teamToReturn = Mapper.Map<TeamModel>(teamEntity);
            return CreatedAtRoute("GetTeam", new { id = teamEntity.Id });
        }

    }
}
