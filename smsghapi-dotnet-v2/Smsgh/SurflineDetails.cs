using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace smsghapi_dotnet_v2.Smsgh
{
  
    public class Bundle
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public string ShortName { get; set; }
        public string BundleValue { get; set; }

    }

    public class SurflineDetails : SurflineCommon 
    {

        public SurflineDetails()
        {
            Bundles = new List<Bundle>();
            SurfBundles = new Bundles();
        }

        public List<Bundle> Bundles { get; set; }
        public Bundles SurfBundles { get; set; }
    }

    public class SurflineCommon : BrokerErrorCode
    {
        public SurflineCommon()
        {
            EndPoints = new List<string>();
            Details = new Details();
        }
        public string ServiceName { get; set; }
        public string Device { get; set; }
        public List<string> EndPoints { get; set; }
        public Details Details { get; set; }
    }
}
