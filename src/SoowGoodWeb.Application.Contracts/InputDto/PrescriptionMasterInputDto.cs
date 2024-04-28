using SoowGoodWeb.DtoModels;
using SoowGoodWeb.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace SoowGoodWeb.InputDto
{
    public class PrescriptionMasterInputDto : FullAuditedEntityDto<long>
    {
        public string? RefferenceCode { get; set; }
        public long? AppointmentId { get; set; }
        public string? AppointmentSerial { get; set; }
        public string? AppointmentCode { get; set; }
        public long? DoctorProfileId { get; set; }
        public string? DoctorName { get; set; }
        public string? DoctorCode { get; set; }
        public long? PatientProfileId { get; set; }
        public string? PatientName { get; set; }
        public string? PatientCode { get; set; }
        public int? Age { get; set; }
        public string? PatientAdditionalInfo { get; set; }
        public ConsultancyType? ConsultancyType { get; set; }
        public AppointmentType? AppointmentType { get; set; }
        public DateTime? AppointmentDate { get; set; }
        public DateTime? PrescriptionDate { get; set; }
        public string? PatientLifeStyle { get; set; }
        public DateTime? ReportShowDate { get; set; }
        public DateTime? FollowupDate { get; set; }
        public string? Advice { get; set; }
        public List<PrescriptionPatientDiseaseHistoryInputDto>? PrescriptionPatientDiseaseHistory { get; set; }
        public List<PrescriptionMainComplaintInputDto>? prescriptionMainComplaints { get; set; }
        public List<PrescriptionFindingsObservationsInputDto>? PrescriptionFindingsObservations { get; set; }
        public List<PrescriptionMedicalCheckupsInputDto>? PrescriptionMedicalCheckups { get; set; }
        public List<PrescriptionDrugDetailsInputDto>? PrescriptionDrugDetails { get; set; }

    }
}
