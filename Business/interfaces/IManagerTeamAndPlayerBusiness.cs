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
        Task<bool> AddTeam(Team entity);
        Task<bool> UpdateTeam(Team entity);
        Task<IEnumerable<Player>> GetPlayersForTeam(int teamId);
        Task<Player> GetPlayerForTeam(int teamId, int playerId);
        Task<bool> UpdatePlayer(Player entity);
        Task<bool> AddPlayer(Player playerEntity);
        Task<int> AddPlayers(int teamId, IEnumerable<Player> playersEntity);
        Task<bool> UpdatePlayers(IEnumerable<Player> playersEntity);
        Task<bool> TeamExists(int teamId);
        // Task<bool> AddOrUpdateTeam(Team entity);
    }
}
