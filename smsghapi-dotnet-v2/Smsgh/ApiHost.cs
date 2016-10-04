namespace smsghapi_dotnet_v2.Smsgh
{
    /// <summary>
    ///     Wrapper that sets API EndPoints.
    /// </summary>
    public class ApiHost
    {
        /// <summary>
        ///     ApiHost
        /// </summary>
        public ApiHost()
        {
            Hostname = "api.smsgh.com";
            Port = -1;
            ContextPath = "v3";
            Timeout = 5000;
            EnabledConsoleLog = true;
            SecuredConnection = false;
            Auth = null;
        }


        /// <summary>
        /// </summary>
        /// <param name="auth"></param>
        public ApiHost(IAuth auth) : this()
        {
            Auth = auth;
        }

        /// <summary>
        ///     The hostname
        /// </summary>
        public string Hostname { set; get; }

        /// <summary>
        ///     The Port
        /// </summary>
        public int Port { set; get; }

        /// <summary>
        ///     The context path
        /// </summary>
        public string ContextPath { set; get; }

        /// <summary>
        ///     The request timeout
        /// </summary>
        public int Timeout { set; get; }

        /// <summary>
        ///     Enable console log
        /// </summary>
        public bool EnabledConsoleLog { set; get; }

        /// <summary>
        ///     Http Authorization header
        /// </summary>
        public IAuth Auth { set; get; }

        /// <summary>
        ///     HTTPs or not
        /// </summary>
        public bool SecuredConnection { set; get; }
    }
}