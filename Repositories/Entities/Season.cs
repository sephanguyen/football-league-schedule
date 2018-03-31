using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repositories.Entities
{
    [Table("Seasons")]
    public class Season
    {
        [Column("Id")]
        int Id { get; set; }

        [Column("Name")]
        string Name { get; set; }

        [Column("DateStart")]
        DateTime DateStart { get; set; }

        [Column("DateEnd")]
        DateTime DateEnd { get; set; }
    }
}