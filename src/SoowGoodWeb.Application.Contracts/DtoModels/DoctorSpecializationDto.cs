using SoowGoodWeb.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace SoowGoodWeb.DtoModels
{
    public class DoctorSpecializationDto : FullAuditedEntityDto<long>
    {
        public long? DoctorProfileId { get; set; }
        //public DoctorProfileDto DoctorProfile { get; set; }
        public string? DoctorName { get; set; }
        public long? SpecialityId { get; set; }
        //public SpecialityDto Speciality { get; set; }
        public string? SpecialityName { get; set; }
        public long? SpecializationId { get; set; }
        //public SpecializationDto? Specialization { get; set; }
        public string? SpecializationName { get; set; }
        public string? ServiceDetails { get; set; }
        public string? DocumentName { get; set; }

    }
}
