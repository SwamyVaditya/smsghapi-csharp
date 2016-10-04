using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Serialization;

namespace smsghapi_dotnet_v2.Smsgh
{
    /// <summary>
    /// Resolver for camelcasing Json keys into camel case format
    /// </summary>
    public class CamelcaseContractResolver : DefaultContractResolver
    {
        protected override string ResolvePropertyName(string propertyName)
        {
            return string.Format("{0}{1}",propertyName.Substring(0,1).ToLower(),propertyName.Substring(1));
        }
    }

    /// <summary>
    /// Resolver for lowercase Json keys
    /// </summary>
    public class LowercaseContractResolver : DefaultContractResolver
    {
        protected override string ResolvePropertyName(string propertyName)
        {
            return propertyName.ToLower();
        }
    }
}
