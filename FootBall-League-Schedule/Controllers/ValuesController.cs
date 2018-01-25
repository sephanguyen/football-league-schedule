using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.interfaces;
using Microsoft.AspNetCore.Mvc;
using Model.Model;

namespace FootBallLeagueSchedule.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly ITeamPlayerBusiness _teamPlayerBusiness;

        public ValuesController(ITeamPlayerBusiness teamPlayerBusiness)
        {
            if (teamPlayerBusiness == null)
                throw new ArgumentException("teamPlayerBusiness is null");
            _teamPlayerBusiness = teamPlayerBusiness;
        }
        // GET api/values
        [HttpGet]
        public async Task<IEnumerable<PlayerModel>> Get()
        {
            return await _teamPlayerBusiness.GetAllPlayerWithTeam();
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
