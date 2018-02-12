using ApiConfiguration.Utilities;
using Model.PostParametersModels;
using Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.interfaces
{
    public interface IManagerTeamAndPlayerBusiness
    {
        Task<PagedList<Team>> GetTeams(TeamPostParameterModel teamPostParameterModel);
        Task<Team> GetTeam(int teamId);
        Task<IEnumerable<Player>> GetPlayers();

    }
}
