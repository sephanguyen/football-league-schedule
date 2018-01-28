using MicroOrm.Dapper.Repositories.Attributes;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repositories.Entities
{
    [Table("Players")]
    public class Player
    {
        [Key, Identity]
        public int Id { get; set; }

        [Column("NamePlayer")]
        public string NamePlayer { get; set; }
    }
}
