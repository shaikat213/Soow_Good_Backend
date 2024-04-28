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
    public class FinancialSetup : FullAuditedEntity<long>
    {

        public long? PlatformFacilityId { get; set; }
        public PlatformFacility? PlatformFacility { get; set; }
        public FacilityEntityType? FacilityEntityType { get; set; }
        public DiagonsticServiceType? DiagonsticServiceType { get; set; }
        public long? FacilityEntityID { get; set; }
        public string? AmountIn { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? Amount { get; set; }
        public string? ExternalAmountIn { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? ExternalAmount { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? ProviderAmount { get; set; }
        public int? Vat { get; set; }
        public bool? IsActive { get; set; }    


    }
}
