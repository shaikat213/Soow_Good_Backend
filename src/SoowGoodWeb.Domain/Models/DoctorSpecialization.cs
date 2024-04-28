using SoowGoodWeb.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace SoowGoodWeb.Models
{
    public class DoctorSpecialization : FullAuditedEntity<long>
    {
        public long? DoctorProfileId { get; set; }
        public DoctorProfile? DoctorProfile { get; set; }
        public long? SpecialityId { get; set; }
        public Speciality? Speciality { get; set; }
        public long? SpecializationId { get; set; }
        public Specialization? Specialization { get; set; }
        public string? ServiceDetails { get; set; }
        public string? DocumentName { get; set; }
    }
}
