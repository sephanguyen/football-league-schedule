
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApiConfiguration.Utilities;
using Business.interfaces;
using Model.PostParametersModels;
using Repositories.Entities;
using Repositories.Enum;

namespace Business.implement_fake_data
{
    public class ManagerTeamAndPlayerBusinessFake : IManagerTeamAndPlayerBusiness
    {
        public Task<bool> AddTeam(Team entity)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Player> GetPlayerForTeam(int teamId, int playerId)
        {
            return new Player()
            {
                // Id = 1,
                // FirstName = "Leona",
                // LastName = "Messi",
                // ContractEndDate = DateTime.Now,
                // ContractStartDate = DateTime.Now,
                // DateOfBirth = DateTime.Now,
                // Deleted = StatusDelete.Active,
                // Nationality = "Aghentina",
                // TeamId = 1,
                // Team = new Team()
                // {
                //     Id = 1,
                //     Address = "Catalan",
                //     City = "Catalan",
                //     Deleted = StatusDelete.Active,
                //     Name = "Barcelona",
                //     StadiumName = "Nou Camp"
                // }
            };
        }

        public Task<IEnumerable<Player>> GetPlayers()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Player>> GetPlayersForTeam(int teamId)
        {
            return new List<Player>()
            {
                // new Player()
                // {
                //     Id = 1,
                //     FirstName = "Leona",
                //     LastName = "Messi",
                //     ContractEndDate = DateTime.Now,
                //     ContractStartDate = DateTime.Now,
                //     DateOfBirth = DateTime.Now,
                //     Deleted = StatusDelete.Active,
                //     Nationality = "Aghentina",
                //     TeamId = 1,
                //     Team = new Team()
                //     {
                //         Id = 1,
                //         Address = "Catalan",
                //         City = "Catalan",
                //         Deleted = StatusDelete.Active,
                //         Name = "Barcelona",
                //         StadiumName = "Nou Camp"
                //     }
                // },
                // new Player()
                // {
                //     Id = 1,
                //     FirstName = "Iniesta",
                //     LastName = "Messi",
                //     ContractEndDate = DateTime.Now,
                //     ContractStartDate = DateTime.Now,
                //     DateOfBirth = DateTime.Now,
                //     Deleted = StatusDelete.Active,
                //     Nationality = "Spain",
                //     TeamId = 1,
                //     Team = new Team()
                //     {
                //         Id = 1,
                //         Address = "Catalan",
                //         City = "Catalan",
                //         Deleted = StatusDelete.Active,
                //         Name = "Barcelona",
                //         StadiumName = "Nou Camp"
                //     }
                // }
            };
        }

        public async Task<Team> GetTeam(int teamId)
        {
            return new Team
            {
                // Id = 1,
                // Address = "Catalan",
                // City = "Catalan",
                // Deleted = StatusDelete.Active,
                // Name = "Barcelona",
                // StadiumName = "Nou Camp",
                // Players = new List<Player>()
                // {
                //     new Player()
                //     {
                //         Id = 1,
                //         FirstName = "Leona",
                //         LastName = "Messi",
                //         ContractEndDate = DateTime.Now,
                //         ContractStartDate = DateTime.Now,
                //         DateOfBirth = DateTime.Now,
                //         Deleted = StatusDelete.Active,
                //         Nationality = "Aghentina",
                //         TeamId = 1
                //     }
                // }
            };
        }

        public Task<PagedList<Team>> GetTeams(ListTeamPostParameterModel teamPostParameterModel)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> UpdatePlayer(Player entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateTeam(Team entity)
        {
            throw new NotImplementedException();
        }
    }
}
