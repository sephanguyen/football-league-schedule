using System;
using System.ComponentModel.DataAnnotations.Schema;
using MicroOrm.Dapper.Repositories.Attributes.Joins;
using MicroOrm.Dapper.Repositories.Attributes.LogicalDelete;
using Repositories.Enum;

namespace Repositories.Entities
{
    [Table("Goals")]
    public class Goal
    {
        [Column("PlayerId")]
        public int PlayerId { get; set; }

        [LeftJoin("Players", "Id", "PlayerId")]
        public virtual Player Players { get; set; }

        [Column("MatchId")]
        public long MatchId {get; set; }
        [InnerJoin("Matches", "Id", "MatchId")]
        public virtual Match Match { get; set; }

        [Column("TypeGoalId")]
        public int TypeGoalId { get; set; }
        [InnerJoin("TypeGoal", "Id", "TypeGoalId")]
        public virtual TypeGoal TypeGoal { get; set; }

        [Column("TimeGoal")]
        public DateTime TimeGoal { get; set; }

        [Status]
        [Column("Deleted")]
        public StatusDelete Deleted { get; set; }
    }
}