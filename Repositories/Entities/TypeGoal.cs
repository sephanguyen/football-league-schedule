using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MicroOrm.Dapper.Repositories.Attributes;

namespace Repositories.Entities
{
    [Table("TypeGoal")]
    public class TypeGoal
    {
        [Key, Identity]
        [Column("Id")]
        public int Id { get; set; }

        [Column("Name")]
        public string Name { get; set; }
        [Column("Value")]
        public int Value { get; set; }
    }
}