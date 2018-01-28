using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiConfiguration;
using ApiConfiguration.Env;
using AutoMapper;
using Business.interfaces;
using Microsoft.AspNetCore.Mvc;
using Model.Model;
using Model.ResponseModel.Player;

namespace FootBallLeagueSchedule.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : BaseController
    {
        private readonly ITeamPlayerBusiness _teamPlayerBusiness;


        public ValuesController(ITeamPlayerBusiness teamPlayerBusiness, IApiConfigurationManager apiConfigurationManager) : base(apiConfigurationManager)
        {
            _teamPlayerBusiness = teamPlayerBusiness ?? throw new ArgumentException("teamPlayerBusiness is null");
        }
        // GET api/values
        [HttpGet]
        public async Task<PlayersResponseModel> Get()
        {
            var result  = await _teamPlayerBusiness.GetAllPlayerWithTeam();
            var responseResult = new PlayersResponseModel();
            responseResult.Data = Mapper.Map<IEnumerable<PlayerModel>>(result);
            responseResult.SetStatusCodeAndMessage(SystemSettings.StatusCode.OK,
                                        ApiConfigurationManager.SystemSettings.DictionaryError[SystemSettings.StatusCode.OK]);

            return responseResult;
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
