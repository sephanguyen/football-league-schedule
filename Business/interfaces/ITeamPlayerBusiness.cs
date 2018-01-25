using Model.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.interfaces
{
    public interface ITeamPlayerBusiness
    {
        Task<IEnumerable<PlayerModel>> GetAllPlayerWithTeam();
    }
}
