using System;

namespace Model.PostParametersModels.TeamPostParameter
{
    public class PlayerUpdatePostParameterModel
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string Nationality { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public bool IsForeign { get; set; }
        public string Image { get; set; }
        public int PositionId { get; set; }
    }
}