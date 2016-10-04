using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace smsghapi_dotnet_v2.Smsgh
{
   /// <summary>
   /// 
   /// </summary>
   public class AccountBasedRequest :BrokerRequestCommon
    {
        /// <summary>
        /// 
        /// </summary>
        public string Account { get; set; }

        public ParameterMap GetParameter()
        {
            return base.GetParameter().Set( "account",Account );
        }
    }
}
