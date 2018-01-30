using System;
using System.Collections.Generic;
using System.Text;

namespace FootBallLeagueSchedule.Helpers
{
    public interface ITypeHelperService
    {
        bool TypeHasProperties<T>(string fields);
    }
}
