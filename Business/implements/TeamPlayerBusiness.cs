using Business.interfaces;
using Model.Model;
using Repositories.Repositories.interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.implements
{
    public class TeamPlayerBusiness : BusinessBase, ITeamPlayerBusiness
    {
        private readonly IPlayersRepository _playerRepository;
        public TeamPlayerBusiness(IPlayersRepository playerRepository)
        {
            if (playerRepository == null)
                throw new ArgumentException("playerRepository is null");
            _playerRepository = playerRepository;
        }
        public async Task<IEnumerable<PlayerModel>> GetAllPlayerWithTeam()
        {
            var result = await _playerRepository.FindAllAsync();
            return result;
        }
    }
}
