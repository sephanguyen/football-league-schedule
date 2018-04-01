using System.Collections.Generic;

namespace Model.PostParametersModels.TeamPostParameter
{
    public class TeamCreatePostParameterModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string StadiumName { get; set; }
        public IEnumerable<PlayerCreatePostParameterModel> Players { get; set; }
    }
}
