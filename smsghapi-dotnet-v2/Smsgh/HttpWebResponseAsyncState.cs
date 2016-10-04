using System;
using System.Net;

namespace smsghapi_dotnet_v2.Smsgh {
    public class HttpWebResponseAsyncState {
        public WebResponse WebResponse { set; get; }
        public Exception Exception { set; get; }
        public object State { set; get; }
        public HttpWebRequest HttpWebRequest { set; get; }
    }
}