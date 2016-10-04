using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace smsghapi_dotnet_v2.Smsgh
{
    class VodafoneRequest : BrokerRequestCommon
    {
        public string Service { get; set; }
        public string Account { get; set; }


        public ParameterMap GetParameterMap()
        {
           return  base.GetParameter()
                .Set("Service", Service)
                .Set("Account", Account);
        }
    }
}
