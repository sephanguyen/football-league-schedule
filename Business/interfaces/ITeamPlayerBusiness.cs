using Repositories.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.interfaces
{
    public interface ITeamPlayerBusiness
    {
        Task<IEnumerable<Player>> GetAllPlayerWithTeam();
    }
}
