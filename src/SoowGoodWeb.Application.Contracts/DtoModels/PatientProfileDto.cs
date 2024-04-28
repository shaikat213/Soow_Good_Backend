using SoowGoodWeb.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace SoowGoodWeb.DtoModels
{
    public class PatientProfileDto : FullAuditedEntityDto<long>
    {
        public string? FullName { get; set; }
        public bool? IsSelf { get; set; }
        public string? PatientName { get; set; }
        public string? PatientCode { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int? Age { get; set; }
        public Gender? Gender { get; set; }
        public string? GenderName { get; set; }
        public string? BloodGroup { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? ZipCode { get; set; }
        public string? Country { get; set; }
        public string? MobileNo { get; set; }
        public string? PatientMobileNo { get; set; }
        public string? Email { get; set; }
        public string? PatientEmail { get; set; }
        public string? CreatedBy { get; set; }
        public string? CratorCode { get; set; }
        public string? CreatorRole { get; set; }
        public long? CreatorEntityId { get; set; }
        public Guid? UserId { get; set; }
        public string? ProfileRole { get; set;}
        public string? CreatorName { get; set; }
        public string? BoothName { get; set; }
        public string? AgentMasterName { get; set; }
        public string? AgentSupervisorName { get; set; }
    }
}
