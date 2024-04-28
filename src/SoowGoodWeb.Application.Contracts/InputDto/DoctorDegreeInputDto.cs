using SoowGoodWeb.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace SoowGoodWeb.InputDto
{
    public class DoctorDegreeInputDto : FullAuditedEntityDto<long>
    {
        public long? DoctorProfileId { get; set; }             
        //public DoctorProfileInputDto? DoctorProfile { get; set; }
        public long? DegreeId { get; set; }
        //public DegreeInputDto Degree { get; set; }
        public int? Duration { get; set; }
        public string? DurationType { get; set; }
        public int? PassingYear { get; set; }
        public string? InstituteName { get; set; }
        public string? InstituteCity { get; set; }
        public string? ZipCode { get; set; }
        public string? InstituteCountry { get; set; }
    }
}
