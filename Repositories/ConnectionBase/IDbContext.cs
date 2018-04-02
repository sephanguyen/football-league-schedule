
using MicroOrm.Dapper.Repositories.DbContext;
using Repositories.interfaces;
using Repositories.Repositories.interfaces;

namespace Repositories.ConnectionBase
{
    public interface IDbContext : IDapperDbContext
    {
        IPlayersRepository PlayerRepository { get; }
        ITeamsRepository TeamRepository { get; }

        IMatchRepository MatchRepository { get; }
        IGoalRepository GoalRepository { get; }
    }
}
