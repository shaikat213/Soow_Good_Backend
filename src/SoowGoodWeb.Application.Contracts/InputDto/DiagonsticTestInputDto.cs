using Microsoft.Extensions.DependencyInjection;
using SoowGoodWeb.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace SoowGoodWeb.InputDto
{
    public class DiagonsticTestInputDto : FullAuditedEntityDto<long>
    {
        public long? ServiceProviderId { get; set; }
        public long? PathologyCategoryId { get; set; }        
        public long? PathologyTestId { get; set; }
        public decimal? ProviderRate { get; set; }
    }
}
