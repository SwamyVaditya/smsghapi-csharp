using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace smsghapi_dotnet_v2.Smsgh
{
    /// <summary>
    /// Common to all Broker Post Request
    /// </summary>
    public class BrokerRequestCommon
    {
        /// <summary>
        /// Amount 
        /// </summary>
        public double Amount { get; set; }
        /// <summary>
        /// API token
        /// </summary>
        public string Token { get; set; }
        /// <summary>
        /// ForeignId
        /// </summary>
        public string ForeignId { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ParameterMap GetParameter()
        {

            return new ParameterMap
            {
            
                {"amount",Amount.ToString() },
                {"token",Token },
                {"foreignId",ForeignId },
            };

        }
    }
}
