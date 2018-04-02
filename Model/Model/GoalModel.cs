using System;

namespace Model.Model
{
    public class GoalModel
    {
        public int PlayerId { get; set; }
        public string PlayerName { get; set; }
        public long MatchId { get; set; }
        public string MatchName { get; set; }

        public string TypeGoalName { get; set; }
        public int ValueGoal { get; set; }
        public DateTime TimeGoal { get; set; }
        
    }
}