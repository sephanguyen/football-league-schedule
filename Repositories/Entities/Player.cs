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
        [Column("id")]
        public int Id { get; set; }

        //[Column("name_player")]
        //public string NamePlayer { get; set; }
        [Column("first_name")]
        public string FirstName { get; set; }
        [Column("last_name")]
        public string LastName { get; set; }
        [Column("nationality")]
        public string Nationality { get; set; }
        [Column("date_of_birth")]
        public DateTime? DateOfBirth { get; set; }
        [Column("contract_start_date")]
        public DateTime? ContractStartDate { get; set; }
        [Column("contract_end_date")]
        public DateTime? ContractEndDate { get; set; }
        [Column("image")]
        public string Image { get; set; }
        [Column("team_id")]
        public int TeamId { get; set; }

        [InnerJoin("Teams", "team_id", "id")]
        public virtual Team Team { get; set; }
        [Status]
        [Column("is_deleted")]
        public StatusDelete Deleted { get; set; }
    }
}
