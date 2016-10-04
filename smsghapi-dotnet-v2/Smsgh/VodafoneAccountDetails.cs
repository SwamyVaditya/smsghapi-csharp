using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace smsghapi_dotnet_v2.Smsgh
{
    
    public class Data
    {
        public string AccountNumber { get; set; }
        public string CurrentBalance { get; set; }
        public string ExpiryDate { get; set; }
        public string ProductType { get; set; }
        public string Status { get; set; }
        public string PlanName { get; set; }
        public ContactInfo ContactInfo { get; set; }
    }

    public class VodafoneAccountDetails
    {
        public Data Data { get; set; }
        public AddressInfo AddressInfo { get; set; }
    }

    public class ContactInfo
    {
        public string Email;
        public string MobilePhone;
    }

    public class AddressInfo
    {
        public string Address1;
        public string Address2;
        public string Address3;
        public string Address4;

        /// <summary>
        /// Generation of the Address information eg
        /// PMB AB 98,
		///	KUMASI,Aboabo-Kumasi,Ashanti Region
		///	Adenta,
		///	Asafo
        /// </summary>
        /// <returns></returns>
        public string GetAddress()
        {

            return new StringBuilder().AppendLine(Address1)
                                      .AppendLine(Address2)
                                      .AppendLine(Address3)
                                      .AppendLine(Address4).ToString();
        }
    }

   }
