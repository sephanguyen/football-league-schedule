using System;
using System.Collections.Generic;
using System.Text;

namespace Model.PostParametersModels
{
    public class TeamPostParameterModel : BasePostParameterListModel
    {
        public TeamPostParameterModel()
        {
            OrderBy = "Name";
        }
    }
}
