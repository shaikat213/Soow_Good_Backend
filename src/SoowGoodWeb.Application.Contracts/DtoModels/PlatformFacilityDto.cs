using SoowGoodWeb.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace SoowGoodWeb.DtoModels
{
    public class PlatformFacilityDto : FullAuditedEntityDto<long>
    {
        public string? ServiceName { get; set; }
        public string? Description { get; set; }
        public string? Slug { get; set; }
    }
}
