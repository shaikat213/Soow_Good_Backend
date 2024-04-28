using SoowGoodWeb.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace SoowGoodWeb.InputDto
{
    public class SpecializationInputDto : FullAuditedEntityDto<long>
    {
        public long? SpecialityId { get; set; }
        //public SpecialityInputDto Speciality { get; set; }        
        public string? SpecializationName { get; set; }
        public string? Description { get; set; }
    }
}
