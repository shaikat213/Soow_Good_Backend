using SoowGoodWeb.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace SoowGoodWeb.InputDto
{
    public class CommonDiseaseInputDto : FullAuditedEntityDto<long>
    {
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

    }
}
