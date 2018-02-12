﻿using MicroOrm.Dapper.Repositories;
using Repositories.Entities;

namespace Repositories.Repositories.interfaces
{
    public interface ITeamsRepository : IDapperRepository<Team>
    {
    }
}
