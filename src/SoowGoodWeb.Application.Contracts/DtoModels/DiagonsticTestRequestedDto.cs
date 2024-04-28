using Microsoft.Extensions.DependencyInjection;
using SoowGoodWeb.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace SoowGoodWeb.DtoModels
{
    public class DiagonsticTestRequestedDto : FullAuditedEntityDto<long>
    {
        public long? DiagonsticPathologyServiceManagementId { get; set; }
        public long? DiagonsticTestId { get; set; }
        public string? DiagonsticTestName { get; set; }
        public string? PathologyCategoryAndTest { get; set; }
        public decimal? ProviderRate { get; set; }
    }
}
