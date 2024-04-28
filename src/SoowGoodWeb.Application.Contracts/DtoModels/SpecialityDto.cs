using SoowGoodWeb.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace SoowGoodWeb.DtoModels
{
    public class SpecialityDto : FullAuditedEntityDto<long>
    {
        public string? SpecialityName { get; set; }
        public string? Description { get; set; }
        public List<SpecializationDto>? Specializations { get; set; }
    }
}
