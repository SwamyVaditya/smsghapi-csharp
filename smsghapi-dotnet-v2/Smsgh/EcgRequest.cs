using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smsghapi_dotnet_v2.Smsgh
{
    class EcgRequest : AccountBasedRequest
    {
        public String Name { get; set; }
        public String ServiceType { get; set; }

        public ParameterMap GetParameter()
        {
            return base.GetParameter()
                .Set("name", Name)
                .Set("serviceType",ServiceType);
        }
    }
}
