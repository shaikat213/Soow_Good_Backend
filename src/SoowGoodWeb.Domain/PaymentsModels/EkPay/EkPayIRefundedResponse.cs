namespace SoowGoodWeb.EkPayData
{
    public class EkPayIRefundedResponse
    {
        public string APIConnect { get; set; }
        public string bank_tran_id { get; set; }
        public string tran_id { get; set; }
        public string initiated_on { get; set; }
        public string refunded_on { get; set; }
        public string status { get; set; }
        public string refund_ref_id { get; set; }
    }
}
