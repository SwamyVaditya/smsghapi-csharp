namespace smsghapi_dotnet_v2.Smsgh {
    /// <summary>
    ///     EventArgs used to handle Exceptions
    /// </summary>
    public class HttpRequestExceptionEventArgs {
        public HttpRequestExceptionEventArgs(HttpRequestException exception) { Exception = exception; }

        /// <summary>
        ///     HttpRequest Exception
        /// </summary>
        public HttpRequestException Exception { get; }
    }
}