using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace smsghapi_dotnet_v2.Smsgh
{
    /// <summary>
    /// Broker Services 
    /// </summary>
    public class BrokerService
    {
        public string Name { get; set; }
        public bool Online { get; set; }
        public string UrlAlias { get; set; }
        public string Country { get; set; }
        public double MinimumAmount { get; set; }
        public double MaximumAmount { get; set; }
        public string AmountOptions { get; set; }
    }
}
