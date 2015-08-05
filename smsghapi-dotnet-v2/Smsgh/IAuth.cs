﻿namespace smsghapi_dotnet_v2.Smsgh
{
    /// <summary>
    ///     Http Authorization header interface
    /// </summary>
    public interface IAuth
    {
        /// <summary>
        ///     Return the constructed HTTP Authorization header
        ///     <seealso cref="BasicAuth" />
        ///     <seealso cref="OAuth" />
        /// </summary>
        /// <returns>constructed HTTP Authorization header</returns>
        string GetCredentials();
    }
}