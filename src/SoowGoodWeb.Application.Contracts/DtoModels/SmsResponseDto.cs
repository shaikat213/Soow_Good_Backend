using System;
using System.Collections.Generic;
using System.Text;

namespace SoowGoodWeb.DtoModels
{
    public class SmsResponseDto
    {
        public string? status { get; set; }
        public string? status_code { get; set; }
        public string? error_message { get; set; }
        public List<SmsInfo>? smsinfo { get; set; }

    }

    public class SmsInfo
    {
        public string? sms_status { get; set; }
        public string? status_message { get; set; }
        public string? sms_type { get; set; }
        public string? msisdn { get; set; }
        public string? sms_body { get; set; }
        public string? csms_id { get; set; }
        public string? reference_id { get; set; }
    }
}
