SMSGH Unity API .NET SDK (Release 2)
===================================

## **Overview**

The Unity API .NET SDK is a wrapper built to assist .Net-driven applications developers to interact in a more friendly way with the Unity API.
Its goal is also to provide an easy way for those who do not have much knowledge about the whole HTTP Restful technology to interact with the Unity API.
In that direction there is no need to go and grab a knowledge about HTTP and REST technology. 
All one needs is to have the basic knowledge about the Microsoft C# language. We mean the basics not advanced knowledge.


## **Installation**

The SDK can smoothly run on any .Net Platform if it is compiled in the right environment.
 
To use the SDK all you have to do is to download the **Smsgh** folder from the repository and all of its contents and add it to your project. Also you can download the source code and build it since it 
is a Visual Studio 2013 project. 


## **Usage**

The SDK currently is organized around four main classes:

* *MessagingApi.cs* : 
    It handles sending and receiving messages, NumberPlans, Campaigns, Keywords, Sender IDs and Message Templates management.(For more information about these terms refer to [Our developer site](http://developers.smsgh.com/).)
* *ContactApi.cs* : 
        It handles all contacts related tasks. 
* *AccountApi.cs* : 
        It handles the API Account Holder data.
* *SupportApi.cs* : 
        It helps any developer to interact with our support platform via his application.
* *ContentApi.cs* :
		It handles all content related tasks.

## **Some Quick Start**

* **How to Send a Message**

```c#
    public class Demo
    {
        public static void Main(string[] args)
        {
            const string clientId = "user233";
            const string clientSecret = "password23";
            const string hostname = "api.smsgh.com";
            const string contextPath = "v3";


            try {
                var host = new ApiHost {ContextPath = contextPath, EnabledLog = true, Hostname = hostname, Auth = new BasicAuth(clientId, clientSecret)};

                var messageApi = new MessagingApi(host);
                MessageResponse msg = messageApi.SendQuickMessage("Arsene", "+233247063817", "Hello Big Bro!", true);
                Console.WriteLine(msg.Status);
            }
            catch (Exception e) {
                if (e.GetType() == typeof (HttpRequestException)) {
                    var ex = e as HttpRequestException;
                    if (ex != null && ex.HttpResponse != null) {
                        Console.WriteLine("Error Status Code " + ex.HttpResponse.Status);
                    }
                }
                throw;
            }

            Console.ReadKey();
        }
    }

```

* **How to Schedule a Message**

```c#
    public class Demo
    {
        public static void Main(string[] args)
        {
            const string clientId = "user233";
            const string clientSecret = "password23";
            const string hostname = "api.smsgh.com";
            const string contextPath = "v3";


            try {
                var host = new ApiHost {ContextPath = contextPath, EnabledLog = true, Hostname = hostname, Auth = new BasicAuth(clientId, clientSecret)};

                var messageApi = new MessagingApi(host);
				const string messageId = "9327e44b281049f090fcae3ebbccb883";
                // The message will be sent four days from today
                DateTime sendTime = DateTime.UtcNow.AddDays(4);

                MessageResponse msg = messageApi.ScheduleMessage(messageId, sendTime);
                Console.WriteLine(msg.Status);
            }
            catch (Exception e) {
                if (e.GetType() == typeof (HttpRequestException)) {
                    var ex = e as HttpRequestException;
                    if (ex != null && ex.HttpResponse != null) {
                        Console.WriteLine("Error Status Code " + ex.HttpResponse.Status);
                    }
                }
                throw;
            }

            Console.ReadKey();
        }
    }

```
*Please do explore the MessagingApi class for more functionalities.*

* **How to view Account Details**

```c#
    public class Demo
    {
        public static void Main(string[] args)
        {
            const string clientId = "user233";
            const string clientSecret = "password23";
            const string hostname = "api.smsgh.com";
            const string contextPath = "v3";


            try {
                var host = new ApiHost {ContextPath = contextPath, EnabledLog = true, Hostname = hostname, Auth = new BasicAuth(clientId, clientSecret)};

                var accountApi = new AccountApi(host);
                AccountProfile profile = accountApi.GetAccountProfile();
                Console.WriteLine("Profile Account Id {0}", profile.AccountId);
            }
            catch (Exception e) {
                if (e.GetType() == typeof (HttpRequestException)) {
                    var ex = e as HttpRequestException;
                    if (ex != null && ex.HttpResponse != null) {
                        Console.WriteLine("Error Status Code " + ex.HttpResponse.Status);
                    }
                }
                throw;
            }

            Console.ReadKey();
        }
    }

```

*Please do explore the AccountApi class for more functionalities.*


* **Notes**

The ContactApi, SupportApi and ContentApi classes follow almost the same pattern of functionalities, please do explore them to grab their capabilities.
The methods in those classes are self explanatory.