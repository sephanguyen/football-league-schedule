using Repositories.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Extension
{
    public interface IGeneraterFixture
    {
        IList<Match> RandomMatchs(IList<Team> listTeam);
    }
}
