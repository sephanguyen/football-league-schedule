using ApiConfiguration.Utilities;
using Business.Extension;
using Business.interfaces;
using Business.Services;
using Microsoft.Extensions.Logging;
using Model.Model;
using Model.PostParametersModels;
using Repositories.ConnectionBase;
using Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business.implements
{
    public class ManagerTeamAndPlayerBusiness : BusinessBase, IManagerTeamAndPlayerBusiness
    {
        public ManagerTeamAndPlayerBusiness(IDbContext dbContext, 
                                            ILogger<BusinessBase> logger, 
                                            IPropertyMappingService propertyMappingService) : base(dbContext, logger, propertyMappingService)
        {
        }

        #region Business For Team
        public async Task<PagedList<Team>> GetTeams(ListTeamPostParameterModel teamPostParameterModel)
        {
            IList<Team> collectionBeforePaging = (await DbContext.TeamRepository.FindAllAsync<Player>(null,
                                        x => x.Players)).ToList();
            if (!string.IsNullOrEmpty(teamPostParameterModel.SearchQuery))
            {
                var searchQueryForWhereClause = teamPostParameterModel.SearchQuery.Trim().ToLowerInvariant();
                collectionBeforePaging = collectionBeforePaging.Where(x => x.Name.ToLowerInvariant().Contains(searchQueryForWhereClause)).ToList();
            }
            

            collectionBeforePaging = collectionBeforePaging.ApplySort(teamPostParameterModel.OrderBy, PropertyMappingService.GetPropertyMapping<TeamModel, Team>());

            return PagedList<Team>.Create(collectionBeforePaging, teamPostParameterModel.PageNumber, teamPostParameterModel.PageSize);
        }

        public async Task<Team> GetTeam(int teamId)
        {
            return await DbContext.TeamRepository.FindByIdAsync<Player>(teamId, x => x.Players);
        }

        public async Task<bool> AddTeam(Team entity)
        {
            //await DbContext.TeamRepository.InsertAsync(entity);
            var insertIsComplete = false;
            using (var trans = DbContext.BeginTransaction())
            {
                
            }
            return insertIsComplete;
        }
        public async Task<bool> AddOrUpdateTeam(Team entity)
        {
            var addOrUpdateIsComplete = false;
            using (var trans = DbContext.BeginTransaction())
            {
                if(entity.Id != 0) {
                    var updateTeamSuccess = await DbContext.TeamRepository.UpdateAsync(entity, trans);
                    if (updateTeamSuccess)
                    {
                        entity.Players.Select(c => { c.TeamId = entity.Id; return c; }).ToList();
                        var listPlayerUpdate = entity.Players.Where(p => p.Id != 0);
                        var listPlayerInsert = entity.Players.Where(p=> p.Id == 0);

                        var taskUpdate = DbContext.PlayerRepository.BulkUpdateAsync(listPlayerUpdate, trans);
                        var taskInsert = DbContext.PlayerRepository.BulkInsertAsync(listPlayerInsert, trans);
                        try {
                            await Task.WhenAll(taskUpdate, taskInsert);
                            
                        }
                        catch(Exception) {
                            trans.Rollback();
                        }
                    }
                }else {
                    var createTeamSuccess = await DbContext.TeamRepository.InsertAsync(entity, trans);
                    if (entity.Players.Any() && createTeamSuccess)
                    {
                        entity.Players.Select(c => { c.TeamId = entity.Id; return c; }).ToList();
                        var num = await DbContext.PlayerRepository.BulkInsertAsync(entity.Players, trans);
                        if (num < 0)
                        {
                            trans.Rollback();
                        }
                    }
                }
                
                trans.Commit();
                addOrUpdateIsComplete = true;
            }
            return addOrUpdateIsComplete;
        }
        #endregion

        #region Business For Player

        public async Task<IEnumerable<Player>> GetPlayersForTeam(int teamId)
        {
            return await DbContext.PlayerRepository.FindAllAsync<Team, Position>(x => x.TeamId == teamId, x => x.Team, p => p.Position);
        }

        public async Task<Player> GetPlayerForTeam(int teamId, int playerId)
        {
            return await DbContext.PlayerRepository.FindAsync<Team, Position>(x => x.TeamId == teamId && x.Id == playerId, x => x.Team, p => p.Position);
        }

         public async Task<bool> UpdatePlayer(Player entity)
         {
            return await DbContext.PlayerRepository.UpdateAsync(entity);
         }

        #endregion
    }
}
