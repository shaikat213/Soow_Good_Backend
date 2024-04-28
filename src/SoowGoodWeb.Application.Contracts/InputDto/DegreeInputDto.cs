using SoowGoodWeb.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace SoowGoodWeb.InputDto
{
    public class DegreeInputDto : FullAuditedEntityDto<long>
    {
        public string? DegreeName { get; set; }
        public string? Description { get; set; }
    }
}
