

using System;

namespace Model.Model
{
    public class MatchModel
    {
        public long Id { get; set; }
        public short AwayScore { get; set; }
        public short HomeScore { get; set; }
        public short TotalScore { get; set; }
        public string Match_Date { get; set; }
        public string Match_Time { get; set; }
        public string Match_Day { get; set; }
        public string Stadium { get; set; }
        public int AwayTeamId { get; set; }
        public string AwayTeamName { get; set; }
        public int HomeTeamId { get; set; }
        public string HomeTeamName { get; set; }
    }
}
