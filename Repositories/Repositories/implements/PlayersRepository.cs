﻿
using System.Data;
using Model.Model;
using Repositories.Repositories.interfaces;

namespace Repositories.Repositories.implements
{
    public class PlayersRepository : RepositoryBase<PlayerModel>, IPlayersRepository
    {
        public PlayersRepository(IDbConnection connection) :  base(connection)
        {
        }
    }
}
