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
using Models.ConfigPostParameter;
using Repositories.Entities;

namespace FootBallLeagueSchedule.Controllers
{
    [Route("api/common")]
    public class CommonController : BaseController
    {
        private readonly ICommonManager _commonManager;

        public CommonController(ICommonManager commonManager, IApiConfigurationManager apiConfigurationManager, ILogger<BaseController> logger, IUrlHelper urlHelper, IPropertyMappingService propertyMappingService, ITypeHelperService typeHelperService) : base(apiConfigurationManager, logger, urlHelper, propertyMappingService, typeHelperService)
        {
            _commonManager = commonManager ?? throw new ArgumentException("managerTeamAndPlayerBusiness is null");

        }

        [HttpGet(Name="GetPositions")]
        public async Task<IActionResult> GetPositions()
        {
            var listPosition = await _commonManager.GetPositions();
            return Ok(listPosition);
        } 

        [HttpPost(Name="CreatePosition")]
        public async Task<IActionResult> CreatePosition(string name) {
            if(!(await _commonManager.CreatePosition(name)))
                throw new Exception(message: "Creating a position failed on save."); 
            return Ok("Create position success!");
        }

        [HttpPut(Name="UpdatePosition")]
        public async Task<IActionResult> UpdatePosition(int id, string name) {
            if(!(await _commonManager.PositionExists(id)))
                return NotFound("Position not found");
            if(!(await _commonManager.UpdatePosition(id, name)))
                throw new Exception(message: "Creating a position failed on save."); 
            return Ok("Create position success!");
        }

        [HttpGet(Name="GetTypeGoals")]
        public async Task<IActionResult> GetTypeGoals()
        {
            var listTypeGoal = await _commonManager.GetTypeGoals();
            return Ok(listTypeGoal);
        } 

        [HttpPost(Name="CreateTypeGoal")]
        public async Task<IActionResult> CreateTypeGoal(string name, int value) {
            if(!(await _commonManager.CreateTypeGoal(name, value)))
                throw new Exception(message: "Creating a position failed on save."); 
            return Ok("Create position success!");
        }

        [HttpPut(Name="UpdateTypeGoal")]
        public async Task<IActionResult> UpdateTypeGoal(int id, string name, int value) {
            if(!(await _commonManager.TypeGoalExists(id)))
                return NotFound("Position not found");
            if(!(await _commonManager.UpdateTypeGoal(id, name, value)))
                throw new Exception(message: "Creating a position failed on save."); 
            return Ok("Create position success!");
        }

        [HttpGet(Name="GetConfigsLeague")]
        public async Task<IActionResult> GetConfigsLeague() {
            var configs = await _commonManager.GetConfigsLeague();
            return Ok(configs);
        }

        [HttpPost(Name="CreateConfigLeague")]
        public async Task<IActionResult> CreateConfigLeague(ConfigCreatePostParameter configModel) {
            if(configModel == null)
            {
                return BadRequest();
            }
            var configLeague = Mapper.Map<ConfigLeague>(configModel);
            if(!(await _commonManager.CreateConfigLeague(configLeague)))
                throw new Exception(message: "Creating a config league failed on save."); 
            return Ok("Create config league success!");
        }

        [HttpPut(Name="UpdateConfigLeague")]
        public async Task<IActionResult> UpdateConfigLeague(ConfigUpdateParameter configModel) {
            if(configModel == null)
            {
                return BadRequest();
            }
            if(!(await _commonManager.ConfigExists(configModel.Id)))
                throw new Exception(message: "Creating a position failed on save."); 
            var configLeague = Mapper.Map<ConfigLeague>(configModel);
            if(!(await _commonManager.UpdateConfigLeague(configLeague)))
                throw new Exception(message: "Update a config league failed on save."); 
            return Ok("Create config league success!");
        }

        [HttpPut(Name="UpdateConfigsLeague")]
        public async Task<IActionResult> UpdateConfigsLeague(IEnumerable<ConfigUpdateParameter> configModel) {
            if(configModel == null)
            {
                return BadRequest();
            }
            var configLeague = Mapper.Map<IEnumerable<ConfigLeague>>(configModel);
            if(!(await _commonManager.UpdateConfigsLeague(configLeague)))
                throw new Exception(message: "Update  configs league failed on save."); 
            return Ok("Create configs league success!");
        }
        
    }
}