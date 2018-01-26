
using ApiConfiguration;
using System;
using static ApiConfiguration.Env.SystemSettings;

namespace Model.ReponseModel
{
    public class BaseResponseModel
    {
        public string Message { get; set; }

        public StatusCode StatusCode { get; set; }
        public BaseResponseModel()
        {
            StatusCode = StatusCode.OK;
        }

        public void SetStatusCodeAndMessage(StatusCode statusCode, string message)
        {
            StatusCode = statusCode;
            Message = message;
        }
    }
}
