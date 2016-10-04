using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace smsghapi_dotnet_v2.Smsgh
{
    /// <summary>
    /// 
    /// </summary>
    public class MobileMoneyTransferRequest : BrokerRequestCommon
    {
        public string ReceiverPhone { get; set; }
        public string ReceiverName { get; set; }
        public string Provider { get; set; }
        public string Sender { get; set; }
        public string CallbackUrl { get; set; }
    }
}
