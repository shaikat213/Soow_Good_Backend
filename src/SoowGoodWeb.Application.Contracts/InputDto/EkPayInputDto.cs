namespace SoowGoodWeb.InputDto
{
    public class EkPayInputDto
    {
        public string? ApplicationCode { get; set; }
        public string? TransactionId { get; set; }
        public string? TotalAmount { get; set; }
    }

    public class EkPayTxnInputDto
    {
        public string? mer_reg_id { get; set; }
        public string? mer_pas_key { get; set; }
    
        public string? c_uri { get; set; }
        public string? f_uri { get; set; }
        public string? s_uri { get; set; }

    
        public string? cust_email { get; set; }
        public string? cust_id { get; set; }
        public string? cust_mail_addr { get; set; }
        public string? cust_mobo_no { get; set; }
        public string? cust_name { get; set; }

    
        public string? ord_det { get; set; }
        public string? ord_id { get; set; }
        public string? trnx_amt { get; set; }
        public string? trnx_currency { get; set; }
        public string? trnx_id { get; set; }
    
        public string? ipn_channel { get; set; }
        public string? ipn_email { get; set; }
        public string? ipn_uri { get; set; }
    }
}
