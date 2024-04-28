using SoowGoodWeb.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace SoowGoodWeb.DtoModels
{
    public class DoctorDegreeDto : FullAuditedEntityDto<long>
    {
        public long? DoctorProfileId { get; set; }             
        //public DoctorProfileDto? DoctorProfile { get; set; }
        public string? DoctorName { get; set; }
        public long? DegreeId { get; set; }
        //public DegreeDto? Degree { get; set; }
        public string? DegreeName { get; set; }
        public int? Duration { get; set; }
        public string? DurationType { get; set; }
        public int? PassingYear { get; set; }
        public string? InstituteName { get; set; }
        public string? InstituteCity { get; set; }
        public string? ZipCode { get; set; }
        public string? InstituteCountry { get; set; }
    }
}
