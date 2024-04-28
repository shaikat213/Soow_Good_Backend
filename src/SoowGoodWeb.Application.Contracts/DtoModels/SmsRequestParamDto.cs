using System;
using System.Collections.Generic;
using System.Text;

namespace SoowGoodWeb.DtoModels
{
    public class SmsRequestParamDto
    {
        public string? Msisdn { get; set; }
        public string? Sms { get; set; }
        public string? CsmsId { get; set; }
    }
}
