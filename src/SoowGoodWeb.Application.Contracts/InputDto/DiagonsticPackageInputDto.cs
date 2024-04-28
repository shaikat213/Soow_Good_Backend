using Microsoft.Extensions.DependencyInjection;
using SoowGoodWeb.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace SoowGoodWeb.InputDto
{
    public class DiagonsticPackageInputDto : FullAuditedEntityDto<long>
    {
        public long? ServiceProviderId { get; set; }
        public string? PackageName { get; set; }
        public string? PackageDescription { get; set; }
        public decimal? ProviderRate { get; set; }
    }
}
