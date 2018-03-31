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
        [Column("Id")]
        public int Id { get; set; }

        [Column("Name")]
        public string Name { get; set; }
        [Column("StadiumName")]
        public string StadiumName { get; set; }

        [Column("Logo")]
        public string Logo { get; set; }

        [InnerJoin("Players", "Id", "TeamId")]
        public virtual IEnumerable<Player> Players { get; set; }

        [Status]
        [Column("Deleted")]
        public StatusDelete Deleted { get; set; }
    }
}
