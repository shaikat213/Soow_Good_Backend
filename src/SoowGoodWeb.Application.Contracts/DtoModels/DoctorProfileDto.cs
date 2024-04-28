using SoowGoodWeb.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace SoowGoodWeb.DtoModels
{
    public class DoctorProfileDto : FullAuditedEntityDto<long>
    {
        public string? DoctorCode { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? FullName { get; set; }
        public DoctorTitle? DoctorTitle { get; set; }
        public string? DoctorTitleName { get;set; }
        public DateTime? DateOfBirth { get; set; }
        public Gender? Gender { get; set; }
        public string? GenderName { get; set; }
        public MaritalStatus? MaritalStatus { get; set; }
        public string? MaritalStatusName { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? ZipCode { get; set; }
        public string? Country { get; set; }
        public string? MobileNo { get; set; }
        public string? Email { get; set; }
        public string? IdentityNumber { get; set; }
        public string? BMDCRegNo { get; set; }
        public DateTime? BMDCRegExpiryDate { get; set; }
        public List<DoctorDegreeDto>? Degrees { get; set; }
        public string? Qualifications { get; set; }
        public long? SpecialityId { get; set; }
        public string? SpecialityName { get; set; }
        //public SpecialityDto? Speciality { get; set; }
        public List<DoctorSpecializationDto>? DoctorSpecialization { get; set; }
        public string? AreaOfExperties { get; set; }
        public bool? IsIdFileUploaded { get; set; }
        public bool? IsSpecialityFileUploaded { get; set; }
        public bool? IsActive { get; set; }
        public Guid? UserId { get; set; }
        public bool? IsOnline { get; set; }
        public int? profileStep { get; set; }
        public string? createFrom { get; set; }
        public string? ProfileRole { get; set; }
        public string? ProfilePic { get; set; }
        public decimal? DisplayInstantFeeAsPatient { get; set; }
        public decimal? DisplayInstantFeeAsAgent { get; set; }
        public decimal? DisplayScheduledPatientChamberFee { get; set; }
        public decimal? DisplayScheduledPatientOnlineFee { get; set; }
        public decimal? DisplayScheduledAgentChamberFee { get; set; }
        public decimal? DisplayScheduledAgentOnlineFee { get; set; }
        public decimal? DisplayIndividualInstantOnlineFee { get; set; }
    }
}
