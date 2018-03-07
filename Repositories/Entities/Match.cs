
using MicroOrm.Dapper.Repositories.Attributes;
using MicroOrm.Dapper.Repositories.Attributes.Joins;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repositories.Entities
{
    [Table("Matches")]
    public class Match
    {
        [Key, Identity]
        [Column("id")]
        public long Id { get; set; }

        [Column("away_score")]
        public short AwayScore { get; set; }
        [Column("home_score")]
        public short HomeScore { get; set; }

        [Column("match_date")]
        public DateTime Match_Date { get; set; }

        [Column("stadium")] 
        public string Stadium { get; set; }

        [Column("away_team_id")]
        public int AwayTeamId { get; set; }
        [InnerJoin("Teams", "away_team_id", "id")]
        public virtual Team AwayTeam { get; set; }

        [Column("home_team_id")]
        public int HomeTeamId { get; set; }
        [InnerJoin("Teams", "home_team_id", "id")]
        public virtual Team HomeTeam { get; set; }
    }
}
