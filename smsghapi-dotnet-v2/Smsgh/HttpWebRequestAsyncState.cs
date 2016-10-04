using System;
using System.Net;

namespace smsghapi_dotnet_v2.Smsgh {
    public class HttpWebRequestAsyncState {
        public byte[] RequestBytes { get; set; }
        public HttpWebRequest HttpWebRequest { set; get; }
        public Exception Exception { set; get; }
        public object State { set; get; }
    }
}