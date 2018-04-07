﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Model.PostParametersModels.TeamPostParameter
{
    public class PlayerCreatePostParameterModel
    {
        public string LastName { get; set; }
        public string Nationality { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public bool IsForeign { get; set; }
        public string Image { get; set; }
        public int PositionId { get; set; }
    }
}
