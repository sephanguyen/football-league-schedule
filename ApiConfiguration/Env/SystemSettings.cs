using System;
using System.Collections.Generic;
using System.Text;

namespace ApiConfiguration.Env
{
    public class SystemSettings : BaseSetting
    {
        public Dictionary<StatusCode, string> DictionaryError { get; set; }
        public enum StatusCode
        {
            OK = 0,
            WRONGVALUE = -1
        }

        public SystemSettings(EEnvironment environment) : base(environment)
        {
        }

        protected override void CommonSettings()
        {
            DictionaryError = new Dictionary<StatusCode, string>
            {
                {StatusCode.OK, "Success"},
                {StatusCode.WRONGVALUE, "Wrong value"}
            };
        }

        protected override void InitDev()
        {
        }

        protected override void InitLocal()
        {
        }

        protected override void InitProduct()
        {
        }
    }
}
