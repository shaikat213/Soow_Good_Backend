using SoowGoodWeb.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace SoowGoodWeb.DtoModels
{
    public class SpecializationDto : FullAuditedEntityDto<long>
    {
        public long? SpecialityId { get; set; }
        //public SpecialityDto? Speciality { get; set; }
        public string? SpecialityName { get; set; }
        public string? SpecializationName { get; set; }
        public string? Description { get; set; }
    }
}
