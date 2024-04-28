using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

namespace SoowGoodWeb.SslCommerzData
{
    public static class NVCExtender
    {
        public static IDictionary<string, string> ToDictionary(this NameValueCollection source)
        {
            return source.AllKeys.ToDictionary(k => k, k => source[k]);
        }
    }
}
