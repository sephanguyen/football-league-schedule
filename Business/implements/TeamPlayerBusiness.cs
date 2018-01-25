using Business.interfaces;
using Model.Model;
using Repositories.ConnectionBase;
using Repositories.Repositories.interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.implements
{
    public class TeamPlayerBusiness : BusinessBase, ITeamPlayerBusiness
    {
        private readonly IDbContext _dbContext;
        public TeamPlayerBusiness(IDbContext dbContext)
        {
            if (dbContext == null)
                throw new ArgumentException("dbContext is null");
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<PlayerModel>> GetAllPlayerWithTeam()
        {
            var result = await _dbContext.PlayerRepository.FindAllAsync();
            return result;
        }

      
    }
}
