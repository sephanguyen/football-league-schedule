using System.Collections.Generic;

namespace Model.MatchPostParameter.PostParametersModels
{
    public class UpdateMatchPostParametersModel
    {
        public int MatchId { get; set; }
        public short ScoreHome { get; set; }
        public short ScoreAway { get; set; }

        public List<GoalPostParametersModelcs> Goals { get; set; }

        
    }
}