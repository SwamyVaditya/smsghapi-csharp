using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace smsghapi_dotnet_v2.Smsgh
{
    /// <summary>
    /// Reponse for must broker request
    /// </summary>
   public class BrokerResponse : BrokerErrorCode
    {
        public string Customer { get; set; }
        public string ForeignId { get; set; }
        public string ProviderId { get; set; }
    }

   public  class BrokerErrorCode
    {
        public string Id { get; set; }
        public string ErrorCode { get; set; }
        public string Description { get; set; }
        [JsonIgnore]
        public bool Successful => (!Id.IsEmpty() && ErrorCode.IsEmpty());

        [JsonIgnore]
        public string ErrorMessage => (Successful)? "": "["+ErrorCode+"] "+Description;


    }
}
