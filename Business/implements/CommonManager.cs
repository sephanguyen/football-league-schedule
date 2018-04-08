using System.Collections.Generic;
using System.Threading.Tasks;
using Business.interfaces;
using Business.Services;
using Microsoft.Extensions.Logging;
using Repositories.ConnectionBase;
using Repositories.Entities;

namespace Business.implements
{
    public class CommonManager : BusinessBase, ICommonManager
    {
        public CommonManager(IDbContext dbContext, ILogger<BusinessBase> logger, IPropertyMappingService propertyMappingService) : base(dbContext, logger, propertyMappingService)
        {
        }

        public async Task<bool> ConfigExists(int id)
        {
            var config = await DbContext.ConfigLeagueRepository.FindByIdAsync(id) ;
            return (config != null ? true : false);  
        }

        public async Task<bool> CreateConfigLeague(ConfigLeague configLeague)
        {
            return await DbContext.ConfigLeagueRepository.InsertAsync(configLeague); 
        }

        public async Task<bool> CreatePosition(string name)
        {
           Position positionInsert = new Position(){ Name = name};
           return await DbContext.PositionsRepository.InsertAsync(positionInsert);
        }

        public async Task<bool> CreateTypeGoal(string name, int value)
        {
            TypeGoal typeGoalInsert = new TypeGoal(){ Name = name, Value = value};
           return await DbContext.TypeGoalsRepository.InsertAsync(typeGoalInsert);
        }

        public async Task<IEnumerable<ConfigLeague>> GetConfigsLeague()
        {
            return await DbContext.ConfigLeagueRepository.FindAllAsync();
        }

        public async Task<IEnumerable<Position>> GetPositions()
        {
            return await DbContext.PositionsRepository.FindAllAsync();
        }

        public async Task<IEnumerable<TypeGoal>> GetTypeGoals()
        {
            return await DbContext.TypeGoalsRepository.FindAllAsync();
        }

        public async Task<bool> PositionExists(int id)
        {
            var position = await DbContext.PositionsRepository.FindByIdAsync(id) ;
            return (position != null ? true : false);
        }

        public async Task<bool> TypeGoalExists(int id)
        {
            var typeGoal = await DbContext.TypeGoalsRepository.FindByIdAsync(id) ;
            return (typeGoal != null ? true : false);
        }

        

        public async Task<bool> UpdateConfigLeague(ConfigLeague configLeague)
        {
            return await DbContext.ConfigLeagueRepository.UpdateAsync(configLeague);
        }

        public async Task<bool> UpdateConfigsLeague(IEnumerable<ConfigLeague> configsLeague)
        {
            return await DbContext.ConfigLeagueRepository.BulkUpdateAsync(configsLeague);
        }

        public async Task<bool> UpdatePosition(int id, string name)
        {
            Position positionUpdate = new Position(){ Id = id, Name = name};
           return await DbContext.PositionsRepository.UpdateAsync(positionUpdate);
        }

        public async Task<bool> UpdateTypeGoal(int id, string name, int value)
        {
           TypeGoal typeGoalUpdate = new TypeGoal(){ Id = id, Name = name, Value = value};
           return await DbContext.TypeGoalsRepository.UpdateAsync(typeGoalUpdate);        
        }
    }
}