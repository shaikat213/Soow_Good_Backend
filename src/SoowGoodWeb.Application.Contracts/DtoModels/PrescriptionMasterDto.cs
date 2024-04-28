using SoowGoodWeb.Enums;
using SoowGoodWeb.InputDto;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace SoowGoodWeb.DtoModels
{
    public class PrescriptionMasterDto : FullAuditedEntityDto<long>
    {
        public string? RefferenceCode { get; set; }
        public long? AppointmentId { get; set; }
        public string? AppointmentSerial { get; set; }
        public string? AppointmentCode { get; set; }
        public long? DoctorProfileId { get; set; }
        public string? DoctorName { get; set; }
        public string? DoctorCode { get; set; }
        public string? DoctorBmdcRegNo { get; set; }
        public long? SpecialityId { get; set; }
        public string? DoctorSpecilityName { get; set; }
        public long? PatientProfileId { get; set; }
        public string? PatientName { get; set; }
        public string? PatientCode { get; set; }
        public int? PatientAge { get; set; }
        public string? PatientBloodGroup { get; set; }
        public string? PatientAdditionalInfo { get; set; }
        public ConsultancyType? ConsultancyType { get; set; }
        public string? ConsultancyTypeName { get; set; }
        public AppointmentType? AppointmentType { get; set; }
        public string? AppointmentTypeName { get; set; }
        public DateTime? AppointmentDate { get; set; }
        public DateTime? PrescriptionDate { get; set; }
        //public string? PatientDiseaseHistory { get; set; }
        public string? PatientLifeStyle { get; set; }
        public DateTime? ReportShowDate { get; set; }
        public DateTime? FollowupDate { get; set; }
        public string? Advice { get; set; }
        public List<PrescriptionPatientDiseaseHistoryDto>? PrescriptionPatientDiseaseHistory { get; set; }
        public List<PrescriptionMainComplaintDto>? prescriptionMainComplaints { get; set; }
        public List<PrescriptionFindingsObservationsDto>? PrescriptionFindingsObservations { get; set; }
        public List<PrescriptionMedicalCheckupsDto>? PrescriptionMedicalCheckups { get; set; }
        public List<PrescriptionDrugDetailsDto>? PrescriptionDrugDetails { get; set; }
    }
}
