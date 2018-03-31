using MicroOrm.Dapper.Repositories.Attributes;
using MicroOrm.Dapper.Repositories.Attributes.Joins;
using MicroOrm.Dapper.Repositories.Attributes.LogicalDelete;
using Repositories.Enum;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repositories.Entities
{
    [Table("Players")]
    public class Player
    {
        [Key, Identity]
        [Column("Id")]
        public int Id { get; set; }

        //[Column("name_player")]
        //public string NamePlayer { get; set; }
        [Column("FirstName")]
        public string FirstName { get; set; }
        [Column("LastName")]
        public string LastName { get; set; }
        [Column("Nationality")]
        public string Nationality { get; set; }
        [Column("DOB")]
        public DateTime? DateOfBirth { get; set; }
    
        [Column("image")]
        public string Image { get; set; }
        [Column("TeamId")]
        public int TeamId { get; set; }

        [InnerJoin("Teams", "TeamId", "Id")]
        public virtual Team Team { get; set; }

        [Column("PositionId")]
        public int PositionId { get; set; }

        [InnerJoin("Positions", "PositionId", "Id")]
        public virtual Position Position { get; set; }

        [Status]
        [Column("IsForeign")]
        public StatusForeign Foreign { get; set; }

        [Status]
        [Column("Deleted")]
        public StatusDelete Deleted { get; set; }
    }
}
