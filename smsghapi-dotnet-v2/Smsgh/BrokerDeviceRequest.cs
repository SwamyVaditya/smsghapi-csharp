using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smsghapi_dotnet_v2.Smsgh
{
   public class BrokerDeviceRequest : BrokerRequestCommon
    {
        public string Device { get; set; }

        public ParameterMap GetParameter()
        {
            return base.GetParameter().Set("device", Device);
        }
    }
}
