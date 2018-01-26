using Model.Model;
using Model.ResponseModel.Player;
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
