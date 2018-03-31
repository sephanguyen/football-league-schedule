
using System;
using System.Collections.Generic;
using Repositories.Entities;

namespace Business.Extension
{
    public class GeneraterRoundRobin : IGeneraterFixture
    {

        public IList<Match> RandomMatchs(IList<Team> listTeam)
        {
            List<Match> listMatch = new List<Match>();
            int num_team = listTeam.Count;
            if (num_team % 2 != 0)
                throw new ArgumentException("teams number is not even number");

            int numRounds = num_team - 1;
            int halfSize = num_team / 2;
            Team firstTeam, secondTeam;
            Match match;
            List<Team> teams = new List<Team>();
            teams.AddRange(listTeam);
            teams.RemoveAt(0);
            int teamsSize = teams.Count;

            for(int round = 0; round < numRounds; round++)
            {
                for(int idx = 1; idx < halfSize; idx++)
                {
                    firstTeam = listTeam[(round + idx) % teamsSize];
                    secondTeam = listTeam[(round + teamsSize - idx) % teamsSize];
                    match = new Match()
                    {
                        TeamHomeId = firstTeam.Id,
                        TeamAwayId = secondTeam.Id,
                        Round = ++round,
                        StadiumName = firstTeam.StadiumName
                    };
                    listMatch.Add(match);
                }
            }
            return listMatch;
        }
    }
}
