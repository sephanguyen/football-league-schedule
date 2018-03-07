using Business.interfaces;
using Microsoft.Extensions.Logging;
using Model.Model;
using Model.PostParametersModels;
using Repositories.ConnectionBase;
using Repositories.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using ApiConfiguration.Utilities;
using Business.Services;
using Business.Extension;
using Model.MatchPostParameter.PostParametersModels;

namespace Business.implements
{
    public class FixtureBusiness : BusinessBase, IFixtureBusiness
    {
        public FixtureBusiness(IDbContext dbContext, ILogger<BusinessBase> logger,
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
                                        x => x.FirstName.ToLowerInvariant().Contains(searchQueryForWhereClause) ||
                                            x.LastName.ToLowerInvariant().Contains(searchQueryForWhereClause)
                                        )).ToList();
            }
            else
            {
                collectionBeforePaging  = (await DbContext.PlayerRepository.FindAllAsync()).ToList();
            }
            
            collectionBeforePaging = collectionBeforePaging.ApplySort(playerPostParameters.OrderBy, PropertyMappingService.GetPropertyMapping<PlayerModel, Player>());

            return PagedList<Player>.Create(collectionBeforePaging, playerPostParameters.PageNumber, playerPostParameters.PageSize);
        }

        public Task<IEnumerable<Match>> GetListFixture(ListFixturePostParametersModel matchPostParameters)
        {
            throw new System.NotImplementedException();
        }
    }
}
