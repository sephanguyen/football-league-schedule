using System;
using System.Collections.Generic;
using System.Text;

namespace Model.PostParametersModels
{
    public class PlayerPostParametersModel : BasePostParameterListModel
    {
        public PlayerPostParametersModel()
        {
            OrderBy = "Name";
        }
    }
}
