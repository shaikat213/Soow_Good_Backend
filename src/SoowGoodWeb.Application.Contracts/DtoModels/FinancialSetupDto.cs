using SoowGoodWeb.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace SoowGoodWeb.DtoModels
{
    public class FinancialSetupDto : FullAuditedEntityDto<long>
    {
        public long? PlatformFacilityId { get; set; }
        public FacilityEntityType? FacilityEntityType { get; set; }
        public string? FacilityEntityTypeName { get; set; }
        public DiagonsticServiceType? DiagonsticServiceType { get; set; }
        public string? DiagonsticServiceTypeName { get; set; }
        public long? FacilityEntityID { get; set; }
        public string? FacilityEntityName { get; set; }
        public string? FacilityName { get; set; }
        public string? AmountIn { get; set; }
        public decimal? Amount { get; set; }
        public string? ExternalAmountIn { get; set; }
        public decimal? ExternalAmount { get; set; }
        public decimal? ProviderAmount { get; set; }
        public bool? IsActive { get; set; }
        public int? Vat { get; set; }
    }
}
