using ApiConfiguration.Utilities;
using Model.PostParametersModels;
using Repositories.Entities;
using System.Threading.Tasks;

namespace Business.interfaces
{
    public interface IFixtureBusiness
    {
        Task<PagedList<Player>> GetAllPlayerWithTeam(PlayerPostParametersModel playerPostParameters);
    }
}
