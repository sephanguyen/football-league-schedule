using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApiConfiguration.Utilities;
using Business.interfaces;
using Model.MatchPostParameter.PostParametersModels;
using Model.PostParametersModels;
using Repositories.Entities;
using Repositories.Enum;

namespace Business.implement_fake_data
{
    public class FixtureBusinessFake : IFixtureBusiness
    {
        public Task<PagedList<Player>> GetAllPlayerWithTeam(PlayerPostParametersModel playerPostParameters)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<Match>> GetListFixture(ListFixturePostParametersModel matchPostParameters)
        {
            
            return new List<Match>() {
                new Match()
                {
                    Id = 1,
                    AwayScore = 2,
                    AwayTeam = new Team()
                    {
                        Id = 1,
                        Name = "Real Madrid"
                    },
                    AwayTeamId = 1,
                    HomeScore = 3,
                    HomeTeam = new Team()
                    {
                        Id = 2,
                        Name = "Barcelona"
                    },
                    HomeTeamId = 2,
                    Match_Date = DateTime.Now,
                    Stadium = "NouCamp"
                }
            };
        }

        
    }
}
