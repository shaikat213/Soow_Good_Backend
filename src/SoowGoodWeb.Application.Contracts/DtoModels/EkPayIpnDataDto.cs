
using Microsoft.Extensions.Hosting;
using System;

namespace SoowGoodWeb.DtoModels
{
    public class EkPayIpnDataDto
    {
        public string? secure_token { get; set; }
        public string? msg_code { get; set; }
        public string? req_timestamp { get; set; }
        public string? mer_reg_id { get; set; }
        public string? ipn_info { get; set; }
        public string? redirect_to { get; set; }
        public string? dgtl_sign { get; set; }
        public string? ord_desc { get; set; }
        public string? remarks { get; set; }
        
        public string? cust_email { get; set; }
        public string? cust_id { get; set; }
        public string? cust_mail_addr { get; set; }
        public string? cust_mobo_no { get; set; }
        public string? cust_name { get; set; }

        public string? trnx_amt { get; set; }
        public string? trnx_id { get; set; }
        public string? mer_trnx_id { get; set; }
        public string? curr { get; set; }
        public string? pi_trnx_id { get; set; }
        public string? pi_charge { get; set; }
        public string? ekpay_charge { get; set; }
        public string? pi_discount { get; set; }
        public string? discount { get; set; }
        public string? promo_discount { get; set; }
        public string? total_ser_chrg { get; set; }
        public string? total_pabl_amt { get; set; }

        public string? pay_timestamp { get; set; }
        public string? pi_name { get; set; }
        public string? pi_type { get; set; }
        public string? pi_number { get; set; }
        public string? pi_gateway { get; set; }
        public string? card_holder_name { get; set; }
    }

    public class basic_Info
    {
        public string? mer_reg_id { get; set; }
        public string? ipn_info { get; set; }
        public string? redirect_to { get; set; }
        public string? dgtl_sign { get; set; }
        public string? ord_desc { get; set; }
        public string? remarks { get; set; }
    }
    public class ipn_data_raw
    {

        public string? secure_token { get; set; }
        public string? msg_code { get; set; }
        public string? req_timestamp { get; set; }
        public basic_Info? basic_info { get; set; }
        public cust_info? cust_info { get; set; }
        public string? scroll_no { get; set; }
        public trnx_info? trnx_info { get; set; }
        public pi_det_info? pi_det_info { get; set; }
    }

    public class trnx_info
    {
        public string? trnx_amt { get; set; }
        public string? trnx_id { get; set; }
        public string? mer_trnx_id { get; set; }
        public string? curr { get; set; }
        public string? pi_trnx_id { get; set; }
        public string? pi_charge { get; set; }
        public string? ekpay_charge { get; set; }
        public string? pi_discount { get; set; }
        public string? discount { get; set; }
        public string? promo_discount { get; set; }
        public string? total_ser_chrg { get; set; }
        public string? total_pabl_amt { get; set; }

    }

    public class pi_det_info
    {
        public string? pay_timestamp { get; set; }
        public string? pi_name { get; set; }
        public string? pi_type { get; set; }
        public string? pi_number { get; set; }
        public string? pi_gateway { get; set; }
        public string? card_holder_name { get; set; }

    }
}
