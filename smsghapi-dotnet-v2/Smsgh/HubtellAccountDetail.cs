using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace smsghapi_dotnet_v2.Smsgh
{
    public class HubtellAccountDetail
    {
        public string AccountId { get; set; }
        public string Balance { get; set; }
        public List<Bundle> Bundles { get; set; }
    }
}
