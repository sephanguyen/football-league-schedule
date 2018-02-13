using ApiConfiguration.Utilities;
using Model.PostParametersModels;
using Repositories.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.interfaces
{
    public interface IManagerTeamAndPlayerBusiness
    {
        Task<PagedList<Team>> GetTeams(ListTeamPostParameterModel teamPostParameterModel);
        Task<Team> GetTeam(int teamId);
        Task<IEnumerable<Player>> GetPlayers();
        Task<bool> AddTeam(Team entity);
    }
}
