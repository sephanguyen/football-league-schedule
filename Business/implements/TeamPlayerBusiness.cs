using ApiConfiguration;
using ApiConfiguration.Env;
using Business.interfaces;
using Model.Model;
using Model.ResponseModel.Player;
using Repositories.ConnectionBase;
using Repositories.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.implements
{
    public class TeamPlayerBusiness : BusinessBase, ITeamPlayerBusiness
    {
        public TeamPlayerBusiness(IDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Player>> GetAllPlayerWithTeam()
        {
            
            return await DbContext.PlayerRepository.FindAllAsync();
        }

      
    }
}
