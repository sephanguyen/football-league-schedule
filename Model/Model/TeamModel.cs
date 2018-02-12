using System.Collections.Generic;

namespace Model.Model
{
    public class TeamModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string StadiumName { get; set; }
        public IEnumerable<PlayerModel> Players { get; set; }

    }
}