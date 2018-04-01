

using Repositories.Enum;
using System;

namespace Model.Model
{
    public class PlayerModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Nationality { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int Age { get; set; }
       
        public string Image { get; set; }
        public int TeamId { get; set; }
        public string TeamName { get; set; }

        public StatusForeign IsForeign { get; set; }

        public int PositionId { get; set; }
        public string PositionName { get; set; }

    }
}
