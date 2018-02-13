
using MicroOrm.Dapper.Repositories.DbContext;
using Repositories.Repositories.interfaces;

namespace Repositories.ConnectionBase
{
    public interface IDbContext : IDapperDbContext
    {
        IPlayersRepository PlayerRepository { get; }
        ITeamsRepository TeamRepository { get; }
    }
}
