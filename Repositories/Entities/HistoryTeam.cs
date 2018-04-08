using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MicroOrm.Dapper.Repositories.Attributes.Joins;

namespace Repositories.Entities
{
    
    [Table("HistoryTeamOfLeague")]
    public class HistoryTeam
    {
        [Column("TeamId")]
        [Key]
        public int TeamId { get ; set; }
        
        [InnerJoin("Teams", "TeamId", "Id")]
        public virtual Team Team { get; set; }

        [Column("SeasonId")]
        [Key]
        public int SeasonId { get; set; }
        [InnerJoin("Seasons", "SeasonId", "Id")]
        public virtual Season Season { get; set; }

        [Column("MatchWin")]
        public int MatchsWin { get; set; }

        [Column("MatchLose")]
        public int MatchsLose { get; set; }

        [Column("MatchDraw")]
        public int MatchsDraw { get; set; }

        [Column("Goals")]
        public int Goals { get; set; }

        [Column("GoalsLost")]
        public int GoalsLost { get; set; }
    }
}