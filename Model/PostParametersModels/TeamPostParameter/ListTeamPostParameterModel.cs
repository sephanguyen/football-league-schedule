using System;
using System.Collections.Generic;
using System.Text;

namespace Model.PostParametersModels
{
    public class ListTeamPostParameterModel : BasePostParameterListModel
    {
        public ListTeamPostParameterModel()
        {
            OrderBy = "Name";
        }
    }
}
