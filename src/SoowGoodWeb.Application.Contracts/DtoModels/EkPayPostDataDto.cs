
using Microsoft.Extensions.Hosting;
using System;

namespace SoowGoodWeb.DtoModels
{
    public class EkPayDataRawDto
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

    public class data_raw
    {
        public mer_info? mer_info { get; set; }
        public string? req_timestamp { get; set; }
        public feed_uri? feed_uri { get; set; }
        public cust_info? cust_info { get; set; }
        public trns_info? trns_info { get; set; }
        public ipn_info? ipn_info { get; set; }
        public string? mac_addr { get; set; }
    }
    public class mer_info
    {
        public string? mer_reg_id { get; set; }
        public string? mer_pas_key { get; set; }
    }
    public class feed_uri
    {
        public string? c_uri { get; set; }
        public string? f_uri { get; set; }
        public string? s_uri { get; set; }

    }
    public class cust_info
    {
        public string? cust_email { get; set; }
        public string? cust_id { get; set; }
        public string? cust_mail_addr { get; set; }
        public string? cust_mobo_no { get; set; }
        public string? cust_name { get; set; }

    }

    public class trns_info
    {
        public string? ord_det { get; set; }
        public string? ord_id { get; set; }
        public string? trnx_amt { get; set; }
        public string? trnx_currency { get; set; }
        public string? trnx_id { get; set; }
    }

    public class ipn_info
    {
        public string? ipn_channel { get; set; }
        public string? ipn_email { get; set; }
        public string? ipn_uri { get; set; }
    }


}
