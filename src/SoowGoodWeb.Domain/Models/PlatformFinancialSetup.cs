using SoowGoodWeb.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace SoowGoodWeb.Models
{
    public class PlatformFinancialSetup : FullAuditedEntity<long>
    {

        public long? PlatformServiceId { get; set; }
        public PlatformService? PlatformService { get; set; }
        public string? AmountIn { get; set; } //Percent Or Flat Amount
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? FeeAmount { get; set; }
        public string? ExternalAmountIn { get; set; } //Percent Or Flat Amount
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? ExternalFeeAmount { get; set; }
        public bool? IsActive { get; set; }
    }
}
