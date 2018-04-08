using System.Collections.Generic;
using System.Threading.Tasks;
using Repositories.Entities;

namespace Business.interfaces
{
    public interface ICommonManager
    {
        Task<IEnumerable<Position>> GetPositions();

        Task<IEnumerable<TypeGoal>> GetTypeGoals();
        Task<bool> CreatePosition(string name);
        Task<bool> PositionExists(int id);
        Task<bool> UpdatePosition(int id, string name);
        Task<bool> CreateTypeGoal(string name, int value);
        Task<bool> TypeGoalExists(int id);
        Task<bool> UpdateTypeGoal(int id, string name, int value);
        Task<IEnumerable<ConfigLeague>> GetConfigsLeague();
        Task<bool> CreateConfigLeague(ConfigLeague configLeague);
        Task<bool> UpdateConfigLeague(ConfigLeague configLeague);
        Task<bool> ConfigExists(int id);
        Task<bool> UpdateConfigsLeague(IEnumerable<ConfigLeague> configLeague);
    }
}