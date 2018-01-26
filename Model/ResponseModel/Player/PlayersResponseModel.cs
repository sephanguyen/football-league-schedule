using ApiConfiguration;
using Model.Model;
using Model.ReponseModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.ResponseModel.Player
{
    public class PlayersResponseModel : BaseResponseModel
    {

        public IEnumerable<PlayerModel> Data { get; set; }
    }
}
