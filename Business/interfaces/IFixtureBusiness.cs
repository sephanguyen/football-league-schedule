using ApiConfiguration.Utilities;
using Model.MatchPostParameter.PostParametersModels;
using Model.PostParametersModels;
using Repositories.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.interfaces
{
    public interface IFixtureBusiness
    {
        Task<PagedList<Player>> GetAllPlayerWithTeam(PlayerPostParametersModel playerPostParameters);

        Task<IEnumerable<Match>> GetListFixture(ListFixturePostParametersModel matchPostParameters);

        Task<IEnumerable<Match>> GenerateFixture();
        Task<bool> UpdateMatch(UpdateMatchPostParametersModel updateMatchModelPostParameter) ;
       
    }
}
