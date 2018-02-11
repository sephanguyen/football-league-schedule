using MicroOrm.Dapper.Repositories.Attributes;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repositories.Entities
{
    [Table("Teams")]
    public class Team
    {
        [Key, Identity]
        [Column("team_id")]
        public int Id { get; set; }
        [Column("city")]
        public string City { get; set; }
        [Column("adress")]
        public string Adress { get; set; }
        [Column("adress")]
        public string stadium_name { get; set; }
        public IEnumerable<Player> Players { get; set; }
    }
}
