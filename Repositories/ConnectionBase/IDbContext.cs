
using Repositories.Repositories.interfaces;

namespace Repositories.ConnectionBase
{
    public interface IDbContext
    {
        IPlayersRepository PlayerRepository { get; }
        ITeamsRepository TeamRepository { get; }
    }
}
