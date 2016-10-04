using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace smsghapi_dotnet_v2.Smsgh
{
    public class CustomerData
    {
        public string CustomerSurname { get; set; }
        public string CustomerStatus { get; set; }
        public string AccountCurrency { get; set; }
        public string AccountType { get; set; }
        public string AccountStatus { get; set; }
        public string LastInvoiceDate { get; set; }
        public string PaymentDueDate { get; set; }
        public string CustomerCellNumber { get; set; }
    }

    public class AccountInfo
    {
        public string DstvSmartCardNumber { get; set; }
        public string RechargeCurrency { get; set; }
    }

    public class DstvAccountInfo
    {
        public CustomerData CustomerData { get; set; }
        public AccountInfo AccountInfo { get; set; }
    }

}
