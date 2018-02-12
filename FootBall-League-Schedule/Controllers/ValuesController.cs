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
using Model.Model;
using Model.PostParametersModels;
using Repositories.Entities;

namespace FootBallLeagueSchedule.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : BaseController
    {
        private readonly IFixtureBusiness _teamPlayerBusiness;


        public ValuesController(IFixtureBusiness teamPlayerBusiness, 
                                IApiConfigurationManager apiConfigurationManager,
                                ILogger<BaseController> logger,
                                IUrlHelper urlHelper,
                                IPropertyMappingService propertyMappingService,
                                ITypeHelperService typeHelperService) : base(apiConfigurationManager, logger, urlHelper, propertyMappingService, typeHelperService)
        {
            _teamPlayerBusiness = teamPlayerBusiness ?? throw new ArgumentException("teamPlayerBusiness is null");
        }
        // GET api/values
        [HttpGet("GetPlayers")]
        public async Task<IActionResult> Get(PlayerPostParametersModel playerPostParameters)
        {
            if(!PropertyMappingService.ValidMappingExistsFor<PlayerModel, Player>(playerPostParameters.OrderBy))
            {
                return BadRequest();
            }
            if(!TypeHelperService.TypeHasProperties<PlayerModel>(playerPostParameters.Fields))
            {
                return BadRequest();
            }
            var playersFromBus  = await _teamPlayerBusiness.GetAllPlayerWithTeam(playerPostParameters);
            var previousPageLink = playersFromBus.HasPrevious ? CreatePlayerResourceUri("GetPlayers", playerPostParameters, ResourceUriType.PreviousPage) : null;
            var nextPageLink = playersFromBus.HasNext ? CreatePlayerResourceUri("GetPlayers", playerPostParameters, ResourceUriType.NextPage) : null;
            var paginationMetadata = new
            {
                totalCount = playersFromBus.Count,
                pageSize = playersFromBus.PageSize,
                currentPage = playersFromBus.CurrentPage,
                totalPages = playersFromBus.TotalPages,
                previousPageLink = previousPageLink,
                nextPageLink = nextPageLink
            };

            Response.Headers.Add("X-Pagination",
                Newtonsoft.Json.JsonConvert.SerializeObject(paginationMetadata));

            var players = Mapper.Map<IEnumerable<PlayerModel>>(playersFromBus);
            return Ok(players.ShapeData(playerPostParameters.Fields));
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        
    }
}
