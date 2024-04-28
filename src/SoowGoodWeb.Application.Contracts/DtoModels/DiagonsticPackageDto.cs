using SoowGoodWeb.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace SoowGoodWeb.DtoModels
{
    public class DiagonsticPackageDto : FullAuditedEntityDto<long>
    {
        public long? ServiceProviderId { get; set; }
        public string? ServiceProviderName { get; set; }
        public string? PackageName { get; set; }
        public string? PackageDescription { get; set; }
        public decimal? ProviderRate { get; set; }
        public decimal? DiscountRate { get; set; }
        public decimal? FinalRate { get; set; }
    }
}
