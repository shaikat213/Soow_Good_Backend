using SoowGoodWeb.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace SoowGoodWeb.InputDto
{
    public class AgentMasterInputDto : FullAuditedEntityDto<long>
    {
        public string? AgentMasterOrgName { get; set; }
        public string? AgentMasterCode { get; set; }
        public string? ContactPerson { get; set; }
        public string? ContactPersonOfficeId { get; set; }
        public string? ContactPersonIdentityNumber { get; set; } //Passport, NID, Driving
        public string? ContactPersongMobileNo { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? ZipCode { get; set; }
        public string? Country { get; set; }
        public string? PhoneNo { get; set; }
        public string? Email { get; set; }
        public string? EmergencyContact { get; set; }
        public string? AgentMasterDocNumber { get; set; } //BIN, TIN, TL Etc
        public DateTime? AgentMasterDocExpireDate { get; set; }
        public bool? IsActive { get; set; }
        public Guid? UserId { get; set; }
    }
}
