using ApiConfiguration.Utilities;
using Model.PostParametersModels;
using Repositories.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.interfaces
{
    public interface ITeamPlayerBusiness
    {
        Task<PagedList<Player>> GetAllPlayerWithTeam(PlayerPostParametersModel playerPostParameters);
    }
}
