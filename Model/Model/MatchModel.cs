

using System;
using System.Collections.Generic;

namespace Model.Model
{
    public class MatchModel
    {
        public long Id { get; set; }
        public short ScoreAway { get; set; }
        public short ScoreHome { get; set; }
        public string MatchDate { get; set; }
        public string MatchTime { get; set; }
        public string MatchDay { get; set; }
        public short Round { get; set; }
        public string StadiumName { get; set; }
        public int TeamAwayId { get; set; }
        public string TeamAwayName { get; set; }
        public int TeamHomeId { get; set; }
        public string TeamHomeName { get; set; }

        public int SeasonId { get; set; }
        public string SeasonName { get; set; }

        public List<GoalModel> Goals { get; set; }
    }
}
