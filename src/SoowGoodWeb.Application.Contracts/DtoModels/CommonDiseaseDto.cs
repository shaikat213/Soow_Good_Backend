using SoowGoodWeb.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace SoowGoodWeb.DtoModels
{
    public class CommonDiseaseDto : FullAuditedEntityDto<long>
    {
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

    }
}
