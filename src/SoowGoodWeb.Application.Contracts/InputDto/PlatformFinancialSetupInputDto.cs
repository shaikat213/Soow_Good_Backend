using SoowGoodWeb.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace SoowGoodWeb.InputDto
{
    public class PlatformFinancialSetupInputDto : FullAuditedEntityDto<long>
    {
        public long? PlatformServiceId { get; set; }
        public string? AmountIn { get; set; } //Percent Or Flat Amount
        public decimal? FeeAmount { get; set; }
        public string? ExternalAmountIn { get; set; } //Percent Or Flat Amount
        public decimal? ExternalFeeAmount { get; set; }
        public bool? IsActive { get; set; }
    }
}
