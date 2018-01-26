using ApiConfiguration;
using ApiConfiguration.Env;
using Business.interfaces;
using Model.Model;
using Model.ResponseModel.Player;
using Repositories.ConnectionBase;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.implements
{
    public class TeamPlayerBusiness : BusinessBase, ITeamPlayerBusiness
    {
        public TeamPlayerBusiness(IDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<PlayerModel>> GetAllPlayerWithTeam()
        {
            
            return await DbContext.PlayerRepository.FindAllAsync();
        }

      
    }
}
