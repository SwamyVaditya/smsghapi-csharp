using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace smsghapi_dotnet_v2.Smsgh
{
    

    public class Details
    {
        public string AccountStatus { get; set; }
        public string AccountType { get; set; }
    }

    public class SurfBundle
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }

    public class SurfPlusBundle
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }

    public class Bundles
    {
        public List<SurfBundle> SurfBundles { get; set; }
        public List<SurfPlusBundle> SurfPlusBundles { get; set; }
    }

    public class SuflinePlusBundleDetail : SurflineCommon
    {
        public Bundles Bundles { get; set; }
    }
}
