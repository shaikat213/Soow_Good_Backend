using System.Collections.Generic;

namespace SoowGoodWeb.EkPayData
{
    public class EkPayInitResponse
    {
        public string status { get; set; }
        public string failedreason { get; set; }
        public string sessionkey { get; set; }
        public Gw gw { get; set; }
        public string redirectGatewayURL { get; set; }
        public string directPaymentURLBank { get; set; }
        public string directPaymentURLCard { get; set; }
        public string directPaymentURL { get; set; }
        public string redirectGatewayURLFailed { get; set; }
        public string GatewayPageURL { get; set; }
        public string storeBanner { get; set; }
        public string storeLogo { get; set; }
        public string store_name { get; set; }
        public List<Desc> desc { get; set; }
        public string is_direct_pay_enable { get; set; }
    }
    public class EkPayTokenResponse
    {
        public string? secure_token { get; set; }
        public string? token_exp_time { get; set; }
        public string? msg_code { get; set; }
        public string? msg_det { get; set; }
        public string? ack_tstamp { get; set; }
        public string? responseCode { get; set; }
        public string? responseMessage { get; set; }
                     
    }

    public class EkPayIpnResponse
    {
        public string? ack_code { get; set; }
        public string? ack_msg { get; set; }
        public string? ack_timestamp { get; set; }
    }

}
