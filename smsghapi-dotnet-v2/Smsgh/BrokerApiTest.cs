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

            const string clientId = "exfcycpd"; //clientId
            const string clientSecret = "qenresmo"; //secreteKey
            const string apiToken = "3a137b8d-468a-4885-81a6-7761808ba255"; //Your api Token
            const string hostname = "api.smsgh.com";
            const string contextPath = "usp/test"; // change to fit when performing live transactions

            try
            {
                var host = new ApiHost {
                    SecuredConnection = securedConnection,
                    ContextPath = contextPath,
                    EnabledConsoleLog = true,
                    Hostname = hostname,
                    Auth = new BasicAuth(clientId, clientSecret)};
                var brokerClient = new BrokerApi(host,apiToken);
                try
                {
                   var response =  brokerClient.BuySurflineBundle("233255000101", 25, "");
                    //var serviceList = brokerClient.GetServiceList();

                    //Console.WriteLine("GOtv payment  : " + serviceList.Count);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception e : "+e.Message);
                }
                try
                {
                    //Test GotvBillPayment
                    //var gotvd = brokerClient.PayGotvBill("12342", 51, "");

                    //Console.WriteLine("GOtv payment  : " + gotvd.ErrorMessage);

                }
                catch (Exception e)
                {

                    Console.WriteLine("Exception e : " + e.Message);
                }
                try
                {


                    //Console.WriteLine("Initiating Airtime Request....");
                  //  var airtime = brokerClient.BuyAirtime("299009999", AirtimeNetwork.Mtn, 1, "");
                  //  if (airtime.Successful)
                  //  {

                  //  }
                  //  else
                  //  {
                  //  }
                  //  Console.WriteLine(string.Format("Response : {0} ", airtime.Successful));
                  //  Console.WriteLine(string.Format("Response : {0} ", airtime.Description));
                  //  var balance = brokerClient.GetAccountBalance();
                  
                  //  ////Test DSTV
                  //  var account = "123456789";
                  //  var amount = 51;
                  //  var foreignId = "";
                  //  var deviceDetails = brokerClient.GetSuflineDeviceDetails(account);

                  ////  var metadata = brokerClient.AirtimeMetadata(phoneNo, network, amount, foreignId);
                  //  var vodafoneAccount = brokerClient.GetVodafoneAccountDetails(account);

                  //  //  var account = "walterdido";
                  //  HubtellAccountDetail hubtelDetails = brokerClient.GetHubtellAccountDetails(account);
                    

                    //Console.WriteLine("Initiating DSTV....");
                    //var dstvPayment = brokerClient.PayDstvRegularBill("12342", 51, "");

                    //Console.WriteLine("Dstv payment  : "+dstvPayment.Successful);



                    //var dstvbo = brokerClient.DstvBoBillPayment("12342", 51, "");

                    //Console.WriteLine("dstvbo payment  : " + dstvbo.Successful);

                    //Console.WriteLine("Initiating DSTV....");
                    //var balanceDetail = brokerClient.GetAccountBalance();

                    //Console.WriteLine("AccountBalance  : " + balanceDetail.AccountBalance);


                    //Console.WriteLine("AccountBalance  : " + balanceDetail.AccountBalance);
                    //Console.WriteLine("Initiating TransferToMobileMoney....");
                    var transferRequest = brokerClient.TransferToMobileMoney("0244123421","kofi",1.3,"MTN","sethPrince","");

                    Console.WriteLine("TransferToMobileMoney  : " + transferRequest.Customer);

                    //Console.WriteLine("Sending Surfline Request....");
                    //var surf = brokerClient.GetSuflineDeviceDetail("233255000111");
                    //Console.WriteLine(string.Format("Response :{0}  ", surf.ServiceName));
                    //Console.WriteLine(string.Format("Response :{0}  ", surf.Device));


                    //var airtimeResponse = brokerClient.BuyAirtime("0249441409", AirtimeNetwork.Mtn, 1, "");
                    //Console.WriteLine(string.Format("Airtime response {0}",airtimeResponse.Id));
                }
                catch (Exception e)
                {

                }

                try
                {
                   
                }
                catch (Exception e)
                {

                }
               

            }
            catch (Exception e)
            {
                if (e.GetType() != typeof (HttpRequestException)) throw;
                var ex = e as HttpRequestException;
                if (ex != null && ex.HttpResponse != null)
                {
                    Console.WriteLine("Error Status Code " + ex.HttpResponse.Status);
                }
                throw;
            }

        }
    }
}
