using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace smsghapi_dotnet_v2.Smsgh
{
  public  class BrokerApiTest
    {

        
        public void TestAll()
        {
         
            const bool securedConnection = true;

            const string clientId = "clientId"; //clientId
            const string clientSecret = "secreteKey"; //secreteKey
            const string apiToken = "broker-api-token-goes-her"; //Your api Token
            const string hostname = "api.smsgh.com";
            const string contextPath = "usp/test"; // change to fit when performing live transactions
            
                var host = new ApiHost {
                    SecuredConnection = securedConnection,
                    ContextPath = contextPath,
                    EnabledConsoleLog = true,
                    Hostname = hostname,
                    Auth = new BasicAuth(clientId, clientSecret)};
                var brokerClient = new BrokerApi(host,apiToken);
            try
            {
                var response = brokerClient.BuyAirtime("23325500010", AirtimeNetwork.Mtn, 25, "");

                //If it fails
                if (!response.Successful)
                {
                   var error =  response.ErrorMessage; //Get what when wrong
                }
            
            }
            catch (Exception e)
                {
                    Console.WriteLine("Exception e : "+e.Message);
                }
                


        }
    }
}
