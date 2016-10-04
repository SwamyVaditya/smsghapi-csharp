using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace smsghapi_dotnet_v2.Smsgh
{
    /// <summary>
    /// Borker Api for accessing all of broker services
    /// </summary>
   public  class BrokerApi : AbstractApi
    {
        private readonly string _apiToken;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="host"></param>
        /// <param name="apiToken"></param>
        public BrokerApi(ApiHost host, string apiToken) : base(host)
        {
            _apiToken = apiToken;
        }

        #region Airtime
        /// <summary>
        /// Performs airtime transaction
        /// </summary>
        /// <param name="request">Must be valid and not null. <see cref="AirtimeRequest"/></param>
        /// <returns>An instance of BrokerResponse</returns>
        public BrokerResponse BuyAirtime(AirtimeRequest request)
        {
            const string resource = "/airtime/";
            return SendPostBrokerRequest(resource, request);
        }

        /// <summary>
        /// Performs airtime transaction
        /// </summary>
        /// <param name="phoneNo">The mobile number.Must be a valid phone number in the country that the operating API token is created from. </param>
        /// <param name="network">The mobile network <see cref="AirtimeNetwork"/></param>
        /// <param name="amount">The amount</param>
        /// <param name="foreignId">The foreign Id</param>
        /// <returns>An instance of BrokerResponse</returns>
        public BrokerResponse BuyAirtime(string phoneNo, AirtimeNetwork network, double amount, string foreignId)
        {
            var request = new AirtimeRequest
            {
                Amount = amount,
                ForeignId = foreignId,
                Network = network,
                Phone = phoneNo,
                Token = _apiToken
            };
            return BuyAirtime(request);

        }


        /// <summary>
        /// Performs airtime transaction
        /// </summary>
        /// <param name="phoneNo">The mobile number.Must be a valid phone number in the country that the operating API token is created from. </param>
        /// <param name="network">The mobile network </param>
        /// <param name="amount">The amount</param>
        /// <param name="foreignId">The foreign Id</param>
        /// <returns>An instance of BrokerResponse</returns>
        public BrokerResponse BuyAirtime(string phoneNo, String network, double amount, string foreignId)
        {
            AirtimeNetwork myNetwork;
            Enum.TryParse(network, out myNetwork);

            var request = new AirtimeRequest
            {
                Amount = amount,
                ForeignId = foreignId,
                Network = myNetwork,
                Phone = phoneNo,
                Token = _apiToken
            };
            return BuyAirtime(request);
        }
        #endregion

        #region MobileMoney

        /// <summary>
        /// Performs mobile money transfer transaction
        /// </summary>
        /// <param name="receiverPhoneNo">The receiver's mobile number. Must be valid and not null.</param>
        /// <param name="receiverName">The receiver's name</param>
        /// <param name="amount">The amount</param>
        /// <param name="foreignId">The foreign Id</param>
        /// <param name="provider">The provider.Must be either  M.</param>
        /// <param name="sender">The sender</param>
        /// <returns>An instance of BrokerResponse</returns>

        public BrokerResponse TransferToMobileMoney(string receiverPhoneNo, string receiverName, double amount, string provider, string sender, string foreignId, string callBack="")
        {
            var request = new MobileMoneyTransferRequest
            {
                Amount = amount,
                ForeignId = foreignId,
                ReceiverPhone = receiverPhoneNo,
                ReceiverName = receiverName,
                Provider = provider,
                Sender = sender,
                Token = _apiToken,
                CallbackUrl = callBack
            };
            return TransferToMobileMoney(request);
        }

        /// <summary>
        /// Performs mobile money transfer transaction
        /// </summary>
        /// <param name="mobileMoneyTransferRequest">Must be valid and not null</param>
        /// <returns>An instance of BrokerResponse</returns>
        public BrokerResponse TransferToMobileMoney(MobileMoneyTransferRequest mobileMoneyTransferRequest)
        {
            return SendPostBrokerRequest("/mobilemoney/", mobileMoneyTransferRequest);
        }

        #endregion

        #region Surfline
        /// <summary>
        /// Performs Surfline top-up transaction
        /// </summary>
        /// <param name="accountBasedRequestRequest">Must be valid and not null.</param>
        /// <param name="endPoint">The URL to which payment will be made either surflineplus or surfline</param>
        /// <returns>An instance of BrokerResponse</returns>
        private BrokerResponse BuySurflineBundle(BrokerDeviceRequest accountBasedRequestRequest, string endPoint)
        {
            var resource = string.Format("/{0}/", endPoint);
            return SendPostBrokerRequest(resource, accountBasedRequestRequest);

        }

        /// <summary>
        /// Performs Surfline top-up transaction
        /// </summary>
        /// <param name="device">Must be valid Surfline number. e.g. 233255xxxxxx</param>
        /// <param name="amount">Must be valid Surfline bundle amount.</param>
        /// <param name="foreignId">The foreign Id</param>
        /// <param name="endPoint">The URL to which payment will be made</param>
        /// <returns>An instance of BrokerResponse</returns>
        public BrokerResponse BuySurflineBundle(string device, double amount, string foreignId, string endPoint)
        {
            return BuySurflineBundle(new BrokerDeviceRequest
            {
                Device = device,
                Amount = amount,
                ForeignId = foreignId,
                Token = _apiToken
            }, endPoint);
        }

        /// <summary>
        ///  Performs Surfline top-up transaction
        /// </summary>
        /// <param name="device">Must be valid Surfline number. e.g. 233255xxxxxx</param>
        /// <param name="amount">Must be valid Surfline bundle amount.</param>
        /// <param name="foreignId">The foreign Id</param>
        /// <returns>An instance of BrokerResponse</returns>
        public BrokerResponse BuySurflineBundle(string device, double amount, string foreignId)
        {
            return BuySurflineBundle(device, amount, foreignId, "surfline");
        }

        /// <summary>
        /// Performs SurflinePlus top-up transaction
        /// </summary>
        /// <param name="device">Must be valid Surfline number. e.g. 233255xxxxxx</param>
        /// <param name="amount">Must be valid Surfline bundle amount.</param>
        /// <param name="foreignId">The foreign Id</param>
        /// <returns>An instance of BrokerResponse</returns>
        public BrokerResponse BuySurflinePlusBundle(string device, double amount, string foreignId)
        {
            return BuySurflineBundle(device, amount, foreignId, "surflineplus");
        }

        #endregion

        #region ECG Bill Payment


        /// <summary>
        /// Performs ECG bills payment
        /// </summary>
        /// <param name="account">Must be valid ECG account number</param>
        /// <param name="amount">Must be valid ECG bill amount</param>
        /// <param name="accountName">Must be valid ECG account name</param>
        /// <param name="serviceType">Must be either postpaid or prepaid. For now, Broker performs only postpaid transactions.</param>
        /// <param name="foreignId">The foreign Id</param>
        /// <returns>An instance of BrokerResponse</returns>
        public BrokerResponse PayEcgBill(string account, double amount, string accountName, string serviceType, string foreignId)
        {
            return SendPostBrokerRequest("ecg", new
            {
                account,
                name = accountName, amount, serviceType, foreignId
            });
        }

        /// <summary>
        /// Performs ECG bills payment
        /// </summary>
        /// <param name="account">Must be valid ECG account number</param>
        /// <param name="amount">Must be valid ECG bill amount</param>
        /// <param name="accountName">Must be valid ECG account name</param>
        /// <param name="foreignId">The foreign Id</param>
        /// <returns>An instance of BrokerResponse</returns>
        public BrokerResponse PayEcgPostPaidBill(string account, double amount, string accountName, string foreignId)
        {
            return PayEcgBill(account, amount, accountName, "postpaid", foreignId);
        }

     
        #endregion

        #region DSTV

        /// <summary>
        /// Performs DStv bill payment transaction
        /// </summary>
        /// <param name="dstvRequest">Must be valid and not null</param>
        /// <param name="urlAlias">The URL alias to which the payment will be made. e.g. dstv, dstvbo, gotv</param>
        /// <returns>An instance of BrokerResponse</returns>
        private BrokerResponse PayDstvBill(DstvRequest dstvRequest, string urlAlias)
        {
            var resource = string.Format("/{0}/", urlAlias);

            return SendPostBrokerRequest(resource, dstvRequest);
        }

        /// <summary>
        /// Performs DStv bill payment transaction
        /// </summary>
        /// <param name="account">Must be valid DStv account number either the customer number or smart card number</param>
        /// <param name="amount">Must be valid DStv amount</param>
        /// <param name="foreignId">The foreign Id</param>
        /// <param name="endPoint">The URL alias to which the payment will be made. e.g. dstv, dstvbo, gotv</param>
        /// <returns>An instance of BrokerResponse</returns>
        private BrokerResponse PayDstvBill(string account, double amount, string foreignId, string endPoint)
        {
            var request = new DstvRequest
            {
                Amount = amount,
                ForeignId = foreignId,
                Account = account,
                Token = _apiToken
            };
            return PayDstvBill(request, endPoint);
        }

   

        /// <summary>
        ///  Performs DStv Regular bill payment transaction
        /// </summary>
        /// <param name="account">Must be valid DStv Regular account number</param>
        /// <param name="amount">Must be valid DStv amount</param>
        /// <param name="foreignId">The foreign Id</param>
        /// <returns>An instance of BrokerResponse</returns>
        public BrokerResponse PayDstvRegularBill(string account, double amount, string foreignId)
        {
            return PayDstvBill(account, amount, foreignId, "dstv");
        }

        /// <summary>
        /// Performs DStv Box Office bill payment transaction
        /// </summary>
        /// <param name="account">Must be valid DStv Regular account number</param>
        /// <param name="amount">Must be valid DStv amount</param>
        /// <param name="foreignId">The foreign Id</param>
        /// <returns>An instance of BrokerResponse</returns>
        public BrokerResponse PayDstvBoBill(string account, double amount, string foreignId)
        {
            return PayDstvBill(account, amount, foreignId, "dstvbo");
        }

        /// <summary>
        ///  Performs DStv Box Office bill payment transaction
        /// </summary>
        /// <param name="request"></param>
        /// <returns>An instance of BrokerResponse</returns>
        public BrokerResponse PayDstvBoBill(DstvRequest request)
        {
            return PayDstvBill(request, "dstvbo");
        }

        /// <summary>**Toedit
        /// Performs GOtv bill payment transaction
        /// </summary>
        /// <param name="account">Must be valid DStv Regular account number</param>
        /// <param name="amount">Must be valid DStv amount</param>
        /// <param name="foreignId">The foreign Id</param>
        /// <returns>An instance of BrokerResponse</returns>
        public BrokerResponse PayGotvBill(string account, double amount, string foreignId)
        {
            return PayDstvBill(account, amount, foreignId, "gotv");
        }
        #endregion

        #region Hubtell topup

        /// <summary>
        /// Performs Hubtell  top-up transaction
        /// </summary>
        /// <param name="hubtellRequest">Must be valid instance of AccountBasedRequest Object and not null</param>
        /// <returns>An instance of BrokerResponse</returns>
        private BrokerResponse BuyHubtellBundle(AccountBasedRequest hubtellRequest)
        {
            var resource = string.Format("/{0}/", "hubtell");
            return SendPostBrokerRequest(resource, hubtellRequest);
        }

        /// <summary>
        /// Performs Hubtell top-up transaction
        /// </summary>
        /// <param name="account">Must be valid Hubtell account name</param>
        /// <param name="amount">Must be valid Hubtell bundle amount</param>
        /// <param name="foreignId">The foreign Id</param>
        /// <returns>An instance of BrokerResponse</returns>
        private BrokerResponse BuyHubtellBundle(string account, double amount, string foreignId)
        {
            var request = new AccountBasedRequest
            {
                Amount = amount,
                ForeignId = foreignId,
                Account = account,
                Token = _apiToken
            };
            return BuyHubtellBundle(request);
        }


        #endregion


        #region Vodafone

        /// <summary>
        /// Performs Vodafone  payment transaction
        /// </summary>
        /// <param name="vodafoneRequest">Must be valid instance of VodafoneRequest Object and not null</param>
        /// <returns>An instance of BrokerResponse</returns>
        private BrokerResponse PayVodafoneBill(VodafoneRequest vodafoneRequest)
        {
            var resource = string.Format("/{0}/", "vodafone");
            return SendPostBrokerRequest(resource, vodafoneRequest);
        }

        /// <summary>
        /// Performs Vodafone  payment transaction
        /// </summary>
        /// <param name="account">Must be valid Vodafone account number</param>
        /// <param name="amount">Must be valid Vodafone amount</param>
        /// <param name="service">Must be valid Vodafone Service eg postpaid</param>
        /// <param name="foreignId">The foreign Id</param>
        /// <returns>An instance of BrokerResponse</returns>
        private BrokerResponse PayVodafoneBill(string account,  double amount, string service, string foreignId)
        {
            var request = new VodafoneRequest
            {
                Amount = amount,
                ForeignId = foreignId,
                Account = account,
                Service = service,
                Token = _apiToken
            };
            return PayVodafoneBill(request);
        }


        #endregion

        #region Broker Commons

        /// <summary>
        /// Sends GET requests to Broker's API service
        /// </summary>
        /// <typeparam name="T">Class for serialisation of the response to</typeparam>
        /// <param name="resource"></param>
        /// <param name="parameterMap"></param>
        /// <returns></returns>
        private T SendGetBrokerRequest<T>(string resource, ParameterMap parameterMap) where T : new()
        {
            Console.WriteLine("Send Request for : "+resource);
            try
            {
                Console.WriteLine("Before");
            var response = RestClient.Get(resource, parameterMap);
                Console.WriteLine("After");
                if (response == null)
                {
                    return Activator.CreateInstance<T>();
                }
        

           // if (response.Status == Convert.ToInt32(HttpStatusCode.OK))
                    return (JsonConvert.DeserializeObject<T>(response.GetBodyAsString()));
            
            //var errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
    
            }
            catch (Exception)
            {
                return Activator.CreateInstance<T>();
            }
            
        }

        /// <summary>
        /// Sends POST requests to Broker's API service
        /// </summary>
        /// <param name="resource"></param>
        /// <param name="requestObject"></param>
        /// <returns></returns>
        public static BrokerResponse SendPostBrokerRequest(string resource, Object requestObject)
        {
            var settings = new JsonSerializerSettings {ContractResolver = new CamelcaseContractResolver()};
            var stringRequest = JsonConvert.SerializeObject(requestObject, Formatting.None, settings);
            const string contentType = "application/json";
            var response = RestClient.Post(resource, contentType, Encoding.UTF8.GetBytes(stringRequest));
            if (response == null)
            {
                return new BrokerResponse
                {
                    ErrorCode = "500.13",
                    Description = "Unable to get server response"
                };
          }
        

            var data = response.Status == Convert.ToInt32(HttpStatusCode.OK) ? response.GetBodyAsString() : response.GetBodyAsString().Replace("\\0", "");
            return (JsonConvert.DeserializeObject<BrokerResponse>(data));

        }
        #endregion

        #region Busy Functions


        private BrokerResponse BuyBusy4GBundle(BrokerDeviceRequest accountBasedRequestRequest, string bundle)
        {
            var resource = string.Format("/{0}/", "busy");
            return SendPostBrokerRequest(resource, new
            {
               Amount = accountBasedRequestRequest.Amount,
               Account = accountBasedRequestRequest.Device,
               Bundle = bundle,
               accountBasedRequestRequest.ForeignId,
               Token = _apiToken
            });
            
        }

        public BrokerResponse BuyBusy4GBundle(string device,string bundle,double amount,string foreignId="")
        {
            return BuyBusy4GBundle(new BrokerDeviceRequest
            {
                Amount = amount,
                Device = device,
                ForeignId = foreignId
            },bundle);
        }
        #endregion

        #region Aero

        /// <summary>
        /// Payment of Aero ticket
        /// </summary>
        /// <param name="account"></param>
        /// <param name="amount"></param>
        /// <param name="foreignId"></param>
        /// <returns></returns>
        public BrokerResponse PayAeroTicket(string account , double amount, string foreignId="")
        {
            return SendPostBrokerRequest("/aero", new
            {
             token  = _apiToken,
             amount,  
             account,
             foreignId
            });
        }

        #endregion


        #region
        /// <summary>
        /// Payment of TV LIcense
        /// </summary>
        /// <param name="account"></param>
        /// <param name="amount"></param>
        /// <param name="foreignId"></param>
        /// <returns></returns>
        public BrokerResponse PayTvLicense(string account, double amount, string foreignId = "")
        {
            return SendPostBrokerRequest("/tvlicense", new
            {
                token = _apiToken,
                amount,
                account,
                foreignId
            });
        }
        #endregion
        #region Get Details Functions
        /// <summary>
        /// Retrieves the wallet balance for a token
        /// </summary>
        /// <param name="token">Must be valid and not null</param>
        /// <returns>An instance of BrokerAccountBalance</returns>
        public BrokerAccountBalance GetAccountBalance(string token)
        {
            return SendGetBrokerRequest<BrokerAccountBalance>(string.Format("/balance/{0}", token), new ParameterMap());
        }


        /// <summary>
        /// Retrieves all active services on Broker
        /// </summary>
        /// <returns>An instance of list of BrokerService</returns>

        public List<BrokerService> GetServiceList()
        {
            return SendGetBrokerRequest<List<BrokerService>>("/services", new ParameterMap());
        }

        /// <summary>
        /// Retrieves the wallet balance for the current token if provided in the constructor
        /// </summary>
        /// <returns>An instance of BrokerAccountBalance</returns>
        public BrokerAccountBalance GetAccountBalance()
        {
            return GetAccountBalance(_apiToken);
        }

        /// <summary>
        /// Retrieves details about a Surfline number
        /// </summary>
        /// <param name="device">Must be valid Surfline number. e.g. 233255xxxxxx</param>
        /// <returns>An instance of SurflineDetails</returns>
        public SurflineDetails GetSuflineDeviceDetails(string device)
        {
            return SendGetBrokerRequest<SurflineDetails>("/surfline", new ParameterMap().Set("device", device));
        }

        /// <summary>
        /// Retrieves details about a Vodafone broadband/postpaid number
        /// </summary>
        /// <param name="account">Must be valid Vodafone broadband/postpaid number</param>
        /// <returns>An instance of VodafoneAccountDetails</returns>
        public VodafoneAccountDetails GetVodafoneAccountDetails(string account)
        {
            return SendGetBrokerRequest<VodafoneAccountDetails>("/vodafone", new ParameterMap().Set("account", account));
        }



        public BusyAccountDetails GetBusyAccountDetails(string account)
        {
            return SendGetBrokerRequest<BusyAccountDetails>("/busy", new ParameterMap().Set("account", account));
        }
        /// <summary>
        /// Retrieves details about a DStv/GOtv account number
        /// </summary>
        /// <param name="account">Must be valid DStv/GOtv account number</param>
        /// <returns>An instance of DstvAccountInfo</returns>
        public DstvAccountInfo GetDstvAccountDetails(string account)
        {
            return SendGetBrokerRequest<DstvAccountInfo>("/dstv", new ParameterMap().Set("account", account));
        }


        /// <summary>
        /// Retrieves details about a Hubtell account
        /// </summary>
        /// <param name="account">Must be valid Hubtell account</param>
        /// <returns>An instance of HubtellAccountDetail</returns>
        public HubtellAccountDetail GetHubtellAccountDetails(string account)
        {
            return SendGetBrokerRequest<HubtellAccountDetail>("/hubtell", new ParameterMap().Set("account", account));
        }


        /// <summary>
        /// Retrieves details about an ECG account
        /// </summary>
        /// <param name="account">Must be valid ECG account</param>
        /// <returns>An instance of EcgAccountDetail</returns>
        public EcgAccountDetail GetEcgAccountDetails(string account)
        {
            return SendGetBrokerRequest<EcgAccountDetail>("/ecg", new ParameterMap().Set("account", account));
        }
        #endregion

        #region Metadata Functions
        /// <summary>
        /// Gets information about charges/commissions to be applied when performing this transaction. Note: this does not debit your Broker wallet.
        /// </summary>
        /// <param name="phoneNo">The mobile number.Must be a valid phone number in the country that the operating API token is created from. </param>
        /// <param name="network">The mobile network <see cref="AirtimeNetwork"/></param>
        /// <param name="amount">The amount</param>
        /// <param name="foreignId">The foreign Id</param>
        /// <returns>An instance of BrokerMetadata</returns>
        public BrokerMetadata GetAirtimeMetadata(string phoneNo, AirtimeNetwork network, double amount, string foreignId)
        {
            return GetAirtimeMetadata(new AirtimeRequest
            {
                Amount = amount,
                ForeignId = foreignId,
                Network = network,
                Phone = phoneNo,
                Token = _apiToken
            });
        }

        /// <summary>
        /// Gets information about charges/commissions to be applied when performing this transaction. Note: this does not debit your Broker wallet.
        /// </summary>
        /// <param name="airtimeRequest">Must be valid and not null</param>
        /// <returns>An instance of BrokerMetadata</returns>
        public BrokerMetadata GetAirtimeMetadata(AirtimeRequest airtimeRequest)
        {
            return GetMetadata(airtimeRequest,"airtime");
        }

        /// <summary>
        /// Gets information about charges/commissions to be applied when performing this transaction. Note: this does not debit your Broker wallet.
        /// </summary>
        /// <param name="mobileMoneyTransferRequest">Must be valid and not null</param>
        /// <returns>An instance of BrokerMetadata</returns>
        public BrokerMetadata GetMobileMoneyTransferMetadata(MobileMoneyTransferRequest  mobileMoneyTransferRequest)
        {
            return GetMetadata(mobileMoneyTransferRequest, "mobilemoney");
        }

        /// <summary>
        /// Gets information about charges/commissions to be applied when performing this transaction. Note: this does not debit your Broker wallet.
        /// </summary>
        /// <param name="receiverPhoneNo">The receiver's mobile number. Must be valid and not null.</param>
        /// <param name="receiverName">The receiver's name</param>
        /// <param name="amount">The amount</param>
        /// <param name="foreignId">The foreign Id</param>
        /// <param name="provider">The provider.Must be either  M.</param>
        /// <param name="sender">The sender</param>
        /// <returns>An instance of BrokerMetadata</returns>
        public BrokerMetadata GetMobileMoneyTransferMetadata(string receiverPhoneNo, string receiverName, double amount, string provider, string sender, string foreignId)
        {
            var request = new MobileMoneyTransferRequest
            {
                Amount = amount,
                ForeignId = foreignId,
                ReceiverPhone = receiverPhoneNo,
                ReceiverName = receiverName,
                Provider = provider,
                Sender = sender,
                Token = _apiToken
            };
            return GetMobileMoneyTransferMetadata(request);
        }

        #region DSTV

        /// <summary>
        /// Gets information about charges/commissions to be applied when performing this transaction. Note: this does not debit your Broker wallet.
        /// </summary>
        /// <param name="dstvRequest">Must be valid and not null</param>
        /// <param name="urlAlias">The URL alias to which the payment will be made. e.g. dstv, dstvbo, gotv</param>
        /// <returns>An instance of BrokerMetadata</returns>
        private BrokerMetadata GetDstvMetadata(DstvRequest dstvRequest, string urlAlias)
        {
                return GetMetadata(dstvRequest, urlAlias);
        }

        /// <summary>
        /// Gets information about charges/commissions to be applied when performing this transaction. Note: this does not debit your Broker wallet.
        /// </summary>
        /// <param name="account">Must be valid DStv Regular account number</param>
        /// <param name="amount">Must be valid DStv amount</param>
        /// <param name="foreignId">The foreign Id</param>
        /// <param name="endPoint">The URL alias to which the payment will be made. e.g. dstv, dstvbo, gotv</param>
        /// <returns>An instance of BrokerMetadata</returns>
        private BrokerMetadata GetDstvMetadata(string account, double amount, string foreignId, string endPoint)
        {
            var request = new DstvRequest
            {
                Amount = amount,
                ForeignId = foreignId,
                Account = account,
                Token = _apiToken
            };
            return GetMetadata(request, endPoint);
        }

        /// <summary>
        /// Gets information about charges/commissions to be applied when performing this transaction. Note: this does not debit your Broker wallet.
        /// </summary>
        /// <param name="account">Must be valid DStv Regular account number</param>
        /// <param name="amount">Must be valid DStv amount</param>
        /// <param name="foreignId">The foreign Id</param>
        /// <returns>An instance of BrokerMetadata</returns>
        public BrokerMetadata GetDstvMetadata(string account, double amount, string foreignId)
        {
            return GetDstvMetadata(account, amount, foreignId, "dstv");
        }

        /// <summary>
        /// Gets information about charges/commissions to be applied when performing this transaction. Note: this does not debit your Broker wallet.
        /// </summary>
        /// <param name="account">Must be valid DStv Regular account number</param>
        /// <param name="amount">Must be valid DStv amount</param>
        /// <param name="foreignId">The foreign Id</param>
        /// <returns>An instance of BrokerMetadata</returns>
        public BrokerMetadata GetGotvMetadata(string account, double amount, string foreignId)
        {
            return GetDstvMetadata(account, amount, foreignId, "gotv");
        }


        /// <summary>
        /// Gets information about charges/commissions to be applied when performing this transaction. Note: this does not debit your Broker wallet.
        /// </summary>
        /// <param name="account">Must be valid DStv Regular account number</param>
        /// <param name="amount">Must be valid DStv amount</param>
        /// <param name="foreignId">The foreign Id</param>
        /// <returns>An instance of BrokerMetadata</returns>
        public BrokerMetadata GetDstvBoMetadata(string account, double amount, string foreignId)
        {
            return GetDstvMetadata(account, amount, foreignId, "dstvbo");
        }


        /// <summary>
        /// Gets information about charges/commissions to be applied when performing this transaction. Note: this does not debit your Broker wallet.
        /// </summary>
        /// <param name="account">Must be valid busy Regular account number</param>
        /// <param name="bundle">Must be valid busy bundle</param>
        /// <param name="amount">Must be valid busy amount</param>
        /// <param name="foreignId">The foreign Id</param>
        /// <returns>An instance of BrokerMetadata</returns>
        public BrokerMetadata GetBusy4GMetadata(string account,string bundle, double amount, string foreignId)
        {
            return GetDstvMetadata(account, amount, foreignId, "busy");
        }


        /// <summary>
        /// Gets information about charges/commissions to be applied when performing this transaction. Note: this does not debit your Broker wallet.
        /// </summary>
        /// <param name="request">Must be valid and not null</param>
        /// <returns>An instance of BrokerMetadata</returns>
        public BrokerMetadata GetDstvBoMetadata(DstvRequest request)
        {
            return GetDstvMetadata(request, "dstvbo");
        }



        /// <summary>
        /// Gets information about charges/commissions to be applied when performing this transaction. Note: this does not debit your Broker wallet.
        /// </summary>
        /// <param name="account">Must be valid Vodafone account number</param>
        /// <param name="service">Must be valid Service eg postpaid, prepaid</param>
        /// <param name="amount">Must be valid Vodafone amount</param>
        /// <param name="foreignId">The foreign Id</param>
        /// <returns>An instance of BrokerMetadata</returns>
        public BrokerMetadata GetVodafoneMetadata(string account, string service, double amount, string foreignId)
        {
            return GetMetadata(new VodafoneRequest
            {
                Account = account,
                Amount = amount,
                Service = service,
                ForeignId = foreignId,
                Token = _apiToken
            }, "vodafone");
        }


        /// <summary>
        /// Gets information about charges/commissions to be applied when performing this transaction. Note: this does not debit your Broker wallet.
        /// </summary>
        /// <param name="account">Must be valid Hubtell account number</param>
        /// <param name="amount">Must be valid Hubtell amount</param>
        /// <param name="foreignId">The foreign Id</param>
        /// <returns>An instance of BrokerMetadata</returns>
        public BrokerMetadata GetHubtellMetadata(string account, double amount, string foreignId)
        {
            return GetMetadata(new AccountBasedRequest
            {
                Account = account,
                Amount = amount,
                ForeignId = foreignId,
                Token = _apiToken
            }, "vodafone");
        }


        /// <summary>
        /// Gets information about charges/commissions to be applied when performing this transaction. Note: this does not debit your Broker wallet.
        /// </summary>
        /// <param name="account">Must be valid Hubtell account number</param>
        /// <param name="amount">Must be valid Hubtell amount</param>
        /// <param name="foreignId">The foreign Id</param>
        /// <returns>An instance of BrokerMetadata</returns>
        public BrokerMetadata GetEcgMetadata(string account, double amount,string accountName,string serviceType, string foreignId)
        {
            return GetMetadata(new EcgRequest
            {
                Account = account,
                Amount = amount,
                ForeignId = foreignId,
                Token = _apiToken
            }, "vodafone");
        }

        #endregion

        /// <summary>
        /// Gets information about charges/commissions to be applied when performing this transaction for a named service. Note: this does not debit your Broker wallet.
        /// </summary>
        /// <param name="requestObject">Must be valid and not null</param>
        /// <param name="serviceName">Name of the service for which metadata is to be retrieved</param>
        /// <returns>An instance of BrokerMetadata</returns>
        public BrokerMetadata GetMetadata(Object requestObject ,string serviceName)
        {
            var settings = new JsonSerializerSettings { ContractResolver = new CamelcaseContractResolver() };
            var stringRequest = JsonConvert.SerializeObject(requestObject, Formatting.None, settings);
            const string contentType = "application/json";
            var response = RestClient.Post(string.Format("/metadata/{0}", serviceName), contentType, Encoding.UTF8.GetBytes(stringRequest));
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            return (JsonConvert.DeserializeObject<BrokerMetadata>(response.GetBodyAsString()));
        }

        #endregion   
    }



    public class BusyAccountDetails
    {
        public string Msisdn { get; set; }
        public List<Bundle> Bundles { get; set; }
    }
}
