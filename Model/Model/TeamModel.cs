using System.Collections.Generic;

namespace Model.Model
{
    public class TeamModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public IEnumerable<PlayerModel> PlayersModel { get; set; }
    }
}