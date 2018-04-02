
using MicroOrm.Dapper.Repositories.Attributes;
using MicroOrm.Dapper.Repositories.Attributes.Joins;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repositories.Entities
{
    [Table("Matches")]
    public class Match
    {
        [Key, Identity]
        [Column("Id")]
        public long Id { get; set; }

        [Column("ScoreHome")]
        public short ScoreHome { get; set; }
        [Column("ScoreAway")]
        public short ScoreAway { get; set; }

        [Column("MatchDate")]
        public DateTime MatchDate { get; set; }
        [Column("Round")]
        public int Round { get; set; }


        [Column("TeamAwayId")]
        public int TeamAwayId { get; set; }
        [InnerJoin("Teams", "TeamAwayId", "Id")]
        public virtual Team TeamAway { get; set; }

        [Column("TeamHomeId")]
        public int TeamHomeId { get; set; }
        [InnerJoin("Teams", "TeamHomeId", "Id")]
        public virtual Team TeamHome { get; set; }

        [Column("SeasonId")]
        public int SeasonId { get; set; }
        [InnerJoin("Seasons", "SeasonId", "Id")]
        public virtual Season Season { get; set; }

        [LeftJoin("Goals", "Id", "MatchesId")]
        public virtual IEnumerable<Goal> Goals { get; set; }

        [Column("StadiumName")]
        public string StadiumName { get; set; }
    }
}
