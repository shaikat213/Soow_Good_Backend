using System.Collections.Generic;

namespace SoowGoodWeb.SslCommerzData
{
    public class SSLCommerzValidatorResponseByTransactionId
    {
        public string status { get; set; }
        public string no_of_trans_found { get; set; }
        public List<Element> element { get; set; }
    }
}
