using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace smsghapi_dotnet_v2.Smsgh
{
    /// <summary>
    /// Airtime Request
    /// </summary>
   public class AirtimeRequest : BrokerRequestCommon
    {
        /// <summary>
        /// The Mobile Network <see cref="AirtimeNetwork"/>
        /// </summary>
        public AirtimeNetwork Network { get; set; }

        /// <summary>
        /// The mobilenumber
        /// </summary>
        public string Phone { get; set; }

    }

    /// <summary>
    /// Enum for the Airtime Networks
    /// </summary>
    public enum AirtimeNetwork
    {
        /// <summary>
        /// Mtn
        /// </summary>
        Mtn = 62001,
        /// <summary>
        /// Vodafone
        /// </summary>
        Vodafone = 62002,
        /// <summary>
        /// Tigo
        /// </summary>
        Tigo = 62003,
        /// <summary>
        /// Expresso
        /// </summary>
        Expresso =62004,
        /// <summary>
        /// Airtel 
        /// </summary>
        Airtel = 62006,
        /// <summary>
        /// Glo
        /// </summary>
        Glo = 62007
    }
}
