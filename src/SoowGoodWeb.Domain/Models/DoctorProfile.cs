using SoowGoodWeb.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace SoowGoodWeb.Models
{
    public class DoctorProfile : FullAuditedEntity<long>
    {
        public string? DoctorCode { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? FullName { get; set; }
        public DoctorTitle? DoctorTitle { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public Gender? Gender { get; set; }
        public MaritalStatus? MaritalStatus { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? ZipCode { get; set; }        
        public string? Country { get; set; }
        public string? MobileNo { get; set; }
        public string? Email { get; set; }
        public string? IdentityNumber { get; set; }
        public string? BMDCRegNo { get; set; }
        public DateTime? BMDCRegExpiryDate { get; set; }
        public List<DoctorDegree>? Degrees { get; set; }
        public long? SpecialityId { get; set; }
        public Speciality? Speciality { get; set; }
        public List<DoctorSpecialization>? DoctorSpecialization { get; set; }
        public bool? IsIdFileUploaded { get; set; }
        public bool? IsSpecialityFileUploaded { get; set; }
        public bool? IsActive { get; set; }
        public Guid? UserId { get; set; }
        public bool? IsOnline { get; set; }
        public int? profileStep { get; set;}
        public string? createFrom { get; set; }

    }
}
