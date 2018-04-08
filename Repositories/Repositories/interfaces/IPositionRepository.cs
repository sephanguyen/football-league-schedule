using MicroOrm.Dapper.Repositories;
using Repositories.Entities;

namespace Repositories.interfaces
{
    public interface IPositionsRepository : IDapperRepository<Position>
    {
        
    }
}