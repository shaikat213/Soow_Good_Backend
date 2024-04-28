
namespace SoowGoodWeb.DtoModels
{
    public class EkPayDto
    {
        public string? status { get; set; }
        public string? failedreason { get; set; }
        public string? sessionkey { get; set; }
        public string? redirectGatewayURL { get; set; }
        public string? directPaymentURLBank { get; set; }
        public string? directPaymentURLCard { get; set; }
        public string? directPaymentURL { get; set; }
        public string? redirectGatewayURLFailed { get; set; }
        public string? GatewayPageURL { get; set; }
        public string? storeBanner { get; set; }
        public string? storeLogo { get; set; }
        public string? store_name { get; set; }
        public string? is_direct_pay_enable { get; set; }
    }
}
