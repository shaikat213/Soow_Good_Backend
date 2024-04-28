using SoowGoodWeb.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace SoowGoodWeb.Models
{
    public class DoctorDegree : FullAuditedEntity<long>
    {

        public long? DoctorProfileId { get; set; }
        public DoctorProfile? DoctorProfile { get; set; }
        public long? DegreeId { get; set; }
        public Degree? Degree { get; set; }
        public int? Duration { get; set; }
        public string? DurationType { get; set; }
        public int? PassingYear { get; set; }
        public string? InstituteName { get; set; }
        public string? InstituteCity { get; set; }
        public string? ZipCode { get; set; }        
        public string? InstituteCountry { get; set; }
    }
}
