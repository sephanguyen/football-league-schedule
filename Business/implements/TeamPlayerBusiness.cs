using ApiConfiguration;
using ApiConfiguration.Env;
using Business.interfaces;
using Microsoft.Extensions.Logging;
using Model.Model;
using Model.PostParametersModels;
using Model.ResponseModel.Player;
using Repositories.ConnectionBase;
using Repositories.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using ApiConfiguration.Utilities;
using Business.Services;
using Business.Extension;

namespace Business.implements
{
    public class TeamPlayerBusiness : BusinessBase, ITeamPlayerBusiness
    {
        public TeamPlayerBusiness(IDbContext dbContext, ILogger<BusinessBase> logger,
                                  IPropertyMappingService propertyMappingService) : base(dbContext, logger, propertyMappingService)
        {
        }

        public async Task<PagedList<Player>> GetAllPlayerWithTeam(PlayerPostParametersModel playerPostParameters)
        {
            IList<Player> collectionBeforePaging; 
            if (!string.IsNullOrEmpty(playerPostParameters.SearchQuery))
            {
                var searchQueryForWhereClause = playerPostParameters.SearchQuery.Trim().ToLowerInvariant();
                collectionBeforePaging = (await DbContext.PlayerRepository.FindAllAsync(
                                        x => x.NamePlayer.ToLowerInvariant().Contains(searchQueryForWhereClause)
                                        )).ToList();
            }
            else
            {
                collectionBeforePaging  = (await DbContext.PlayerRepository.FindAllAsync()).ToList();
            }
            
            collectionBeforePaging = collectionBeforePaging.ApplySort(playerPostParameters.OrderBy, PropertyMappingService.GetPropertyMapping<PlayerModel, Player>());

            return PagedList<Player>.Create(collectionBeforePaging, playerPostParameters.PageNumber, playerPostParameters.PageSize);
        }

      
    }
}
