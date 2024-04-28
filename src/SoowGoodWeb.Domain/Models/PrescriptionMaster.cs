using SoowGoodWeb.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace SoowGoodWeb.Models
{
    public class PrescriptionMaster : FullAuditedEntity<long>
    {
        public string? RefferenceCode { get; set; }
        public long? AppointmentId { get; set; }
        public Appointment? Appointment { get; set; }
        public string? AppointmentSerial { get; set; }
        public string? AppointmentCode { get; set; }
        public long? DoctorProfileId { get; set; }
        public string? DoctorName { get; set; }
        public string? DoctorCode { get; set; }
        public long? PatientProfileId { get; set; }
        public string? PatientName { get; set; }
        public string? PatientCode { get; set; }
        public int? Age { get; set; }
        public ConsultancyType? ConsultancyType { get; set; }
        public AppointmentType? AppointmentType { get; set; }
        public DateTime? AppointmentDate { get; set; }
        public DateTime? PrescriptionDate { get; set; }
        public string? PatientLifeStyle{ get; set; }
        public DateTime? ReportShowDate { get; set; }
        public DateTime? FollowupDate { get; set; }
        public string? Advice { get; set; }
        public List<PrescriptionPatientDiseaseHistory>? PrescriptionPatientDiseaseHistory { get;set; } 
        public List<PrescriptionMainComplaint>? prescriptionMainComplaints { get;set; } 
        public List<PrescriptionFindingsObservations>? PrescriptionFindingsObservations { get;set; } 
        public List<PrescriptionMedicalCheckups>? PrescriptionMedicalCheckups { get;set; } 
        public List<PrescriptionDrugDetails>? PrescriptionDrugDetails { get;set; }
        public string? PatientAdditionalInfo { get; set; }

    }
}
