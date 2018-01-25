
using MicroOrm.Dapper.Repositories.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Model
{
    [Table("Players")]
    public class PlayerModel
    {
        [Key, Identity]
        public int Id { get; set; }

        [Column("NamePlayer")]
        public string Name { get; set; }
    }
}
