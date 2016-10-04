namespace smsghapi_dotnet_v2.Smsgh
{
    /// <summary>
    /// </summary>
    public class Bill
    {
        /// <summary>
        ///     The account holder
        /// </summary>
        public string Account { set; get; }

        /// <summary>
        ///     The Amount to pay
        /// </summary>
        public double Amount { set; get; }

        /// <summary>
        ///     An authentication token
        /// </summary>
        public string Token { set; get; }
    }
}