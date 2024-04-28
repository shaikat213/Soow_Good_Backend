using SoowGoodWeb.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace SoowGoodWeb.InputDto
{
    public class PlatformServiceInputDto : FullAuditedEntityDto<long>
    {
        public string? ServiceName { get; set; }
        public string? ServiceDescription { get; set; }
    }
}
