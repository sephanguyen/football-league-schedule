using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MicroOrm.Dapper.Repositories.Attributes;

namespace Repositories.Entities
{
    [Table("ConfigLeague")]

    public class ConfigLeague
    {
        [Key, Identity]
        [Column("Id")]
        public int Id{ get; set; }
        [Column("Name")]
        public int Name { get; set; }
        [Column("Value")]
        public int Value { get; set; }
        [Column("Description")]
        public string Description { get; set; }
        [Column("Code")]
        public string Code { get; set; }
    }
}