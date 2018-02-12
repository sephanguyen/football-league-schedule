using MicroOrm.Dapper.Repositories.Attributes;
using MicroOrm.Dapper.Repositories.Attributes.Joins;
using MicroOrm.Dapper.Repositories.Attributes.LogicalDelete;
using Repositories.Enum;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repositories.Entities
{
    [Table("Teams")]
    public class Team
    {
        [Key, Identity]
        [Column("id")]
        public int Id { get; set; }
        [Column("city")]
        public string City { get; set; }
        [Column("address")]
        public string Address { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("stadium_name")]
        public string StadiumName { get; set; }

        [InnerJoin("Players", "id", "team_id")]
        public virtual List<Player> Players { get; set; }

        [Status]
        [Column("is_deleted")]
        public StatusDelete Deleted { get; set; }
    }
}
