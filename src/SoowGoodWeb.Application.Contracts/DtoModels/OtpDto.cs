using SoowGoodWeb.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace SoowGoodWeb.DtoModels
{
    public class OtpDto : FullAuditedEntityDto<int>
    {
        public int? OtpNo { get; set; }
        public string? MobileNo { get; set; }
        public OtpStatus? OtpStatus { get; set; }
        public int? MaxAttempt { get; set; }
    }

    public class OtpResultDto : FullAuditedEntityDto<int>
    {
        public bool? Success { get; set; }
        public string? Message { get; set; }
    }
}
