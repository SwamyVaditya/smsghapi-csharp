using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace smsghapi_dotnet_v2.Smsgh
{
    

    public class ServiceDetails
    {
        public int AmountMin { get; set; }
        public int AmountMax { get; set; }
        public string AmountType { get; set; }
        public bool Online { get; set; }
        public bool CommissionEnabled { get; set; }
        public string CommissionMode { get; set; }
        public string CommissionFormula { get; set; }
        public bool ServiceChargeEnabled { get; set; }
        public string ServiceChargeMode { get; set; }
        public string ServiceChargeFormula { get; set; }
    }

    public class Commission
    {
        public bool CommissionEnabled { get; set; }
        public string CommissionMode { get; set; }
        public string CommissionFormula { get; set; }
    }

    public class ServiceCharge
    {
        public bool ServiceChargeEnabled { get; set; }
        public string CommissionMode { get; set; }
        public string ServiceChargeFormula { get; set; }
    }

    public class PerAccountServiceDetails
    {
        public Commission Commission { get; set; }
        public ServiceCharge ServiceCharge { get; set; }
    }

    public class BrokerMetadata
    {
        public string Service { get; set; }
        public string Customer { get; set; }
        public string ForeignId { get; set; }
        public bool IsBundle { get; set; }
        public object BundleValue { get; set; }
        public int Amount { get; set; }
        public double TotalCommission { get; set; }
        public double TotalServiceCharge { get; set; }
        public double Fee { get; set; }
        public ServiceDetails ServiceDetails { get; set; }
        public PerAccountServiceDetails PerAccountServiceDetails { get; set; }
    }
}
