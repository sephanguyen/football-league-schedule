using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiConfiguration;
using ApiConfiguration.Env;
using ApiConfiguration.Utilities;
using AutoMapper;
using Business.interfaces;
using Business.Services;
using FootBallLeagueSchedule.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model.Model;
using Model.PostParametersModels;
using Model.ResponseModel.Player;
using Repositories.Entities;

namespace FootBallLeagueSchedule.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : BaseController
    {
        private readonly ITeamPlayerBusiness _teamPlayerBusiness;


        public ValuesController(ITeamPlayerBusiness teamPlayerBusiness, 
                                IApiConfigurationManager apiConfigurationManager,
                                ILogger<BaseController> logger,
                                IUrlHelper urlHelper,
                                IPropertyMappingService propertyMappingService) : base(apiConfigurationManager, logger, urlHelper, propertyMappingService)
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
            
            var playersResult  = await _teamPlayerBusiness.GetAllPlayerWithTeam(playerPostParameters);
            var previousPageLink = playersResult.HasPrevious ? CreatePlayerResourceUri(playerPostParameters, ResourceUriType.PreviousPage) : null;
            var nextPageLink = playersResult.HasNext ? CreatePlayerResourceUri(playerPostParameters, ResourceUriType.NextPage) : null;
            var paginationMetadata = new
            {
                totalCount = playersResult.Count,
                pageSize = playersResult.PageSize,
                currentPage = playersResult.CurrentPage,
                totalPages = playersResult.TotalPages,
                previousPageLink = previousPageLink,
                nextPageLink = nextPageLink
            };

            Response.Headers.Add("X-Pagination",
                Newtonsoft.Json.JsonConvert.SerializeObject(paginationMetadata));

            return Ok(playersResult);
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

        private string CreatePlayerResourceUri(PlayerPostParametersModel playerPostParametersModel, ResourceUriType type)
        {
            switch(type) {
                case ResourceUriType.PreviousPage:
                    return UrlHelper.Link("GetPlayers", new
                    {
                        orderBy = playerPostParametersModel.OrderBy,
                        searchQuery = playerPostParametersModel.SearchQuery,
                        pageNumber = playerPostParametersModel.PageNumber - 1,
                        pageSize = playerPostParametersModel.PageSize
                    });
                case ResourceUriType.NextPage:
                    return UrlHelper.Link("GetPlayers", new
                    {
                        orderBy = playerPostParametersModel.OrderBy,
                        searchQuery = playerPostParametersModel.SearchQuery,
                        pageNumber = playerPostParametersModel.PageNumber + 1,
                        pageSize = playerPostParametersModel.PageSize
                    });
                default:
                    return UrlHelper.Link("GetPlayers", new
                    {
                        orderBy = playerPostParametersModel.OrderBy,
                        searchQuery = playerPostParametersModel.SearchQuery,
                        pageNumber = playerPostParametersModel.PageNumber,
                        pageSize = playerPostParametersModel.PageSize
                    });

            }
        }
    }
}
