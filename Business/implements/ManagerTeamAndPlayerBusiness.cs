using ApiConfiguration.Utilities;
using Business.Extension;
using Business.interfaces;
using Business.Services;
using Microsoft.Extensions.Logging;
using Model.Model;
using Model.PostParametersModels;
using Repositories.ConnectionBase;
using Repositories.Entities;
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

        public async Task<PagedList<Team>> GetTeams(TeamPostParameterModel teamPostParameterModel)
        {
            IList<Team> collectionBeforePaging;
            if (!string.IsNullOrEmpty(teamPostParameterModel.SearchQuery))
            {
                var searchQueryForWhereClause = teamPostParameterModel.SearchQuery.Trim().ToLowerInvariant();
                collectionBeforePaging = (await DbContext.TeamRepository.FindAllAsync<Player>(
                                        x => x.Name.ToLowerInvariant().Contains(searchQueryForWhereClause), 
                                        y => y.Players)).ToList();
            }
            else
            {
                collectionBeforePaging = (await DbContext.TeamRepository.FindAllAsync<Player>(null,
                                        x => x.Players)).ToList();
            }

            collectionBeforePaging = collectionBeforePaging.ApplySort(teamPostParameterModel.OrderBy, PropertyMappingService.GetPropertyMapping<TeamModel, Team>());

            return PagedList<Team>.Create(collectionBeforePaging, teamPostParameterModel.PageNumber, teamPostParameterModel.PageSize);
        }

        public async Task<Team> GetTeam(int teamId)
        {
            return await DbContext.TeamRepository.FindByIdAsync<Player>(teamId, x => x.Players);
        }
        public async Task<IEnumerable<Player>> GetPlayers()
        {
            return await DbContext.PlayerRepository.FindAllAsync<Team>(x => true, x => x.Team);
        }
    }
}
