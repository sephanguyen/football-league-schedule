using System;
using System.Collections.Generic;
using System.Text;

namespace Model.PostParametersModels.TeamPostParameter
{
    public class PlayerCreatePostParameterModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nationality { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? ContractStartDate { get; set; }
        public DateTime? ContractEndDate { get; set; }
        public bool IsForeign { get; set; }
        public string Image { get; set; }
    }
}
