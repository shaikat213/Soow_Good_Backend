using SoowGoodWeb.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace SoowGoodWeb.DtoModels
{
    public class AgentSupervisorDto : FullAuditedEntityDto<long>
    {
        public long? AgentMasterId { get; set; }//dropdown
        public string? AgentMasterName { get; set; }
        public string? AgentSupervisorOrgName { get; set; }
        public string? AgentSupervisorCode { get; set; }
        public string? SupervisorName { get; set; }
        //public string? ContactPersonOfficeId { get; set; }
        public string? SupervisorIdentityNumber { get; set; } //Passport, NID, Driving
        public string? SupervisorMobileNo { get; set; }//userName
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? ZipCode { get; set; }
        public string? Country { get; set; }
        public string? PhoneNo { get; set; }
        public string? Email { get; set; }
        public string? EmergencyContact { get; set; }
        public string? AgentSupervisorDocNumber { get; set; } //BIN, TIN, TL Etc
        public DateTime? AgentSupervisorDocExpireDate { get; set; }
        public bool? IsActive { get; set; }
        public Guid? UserId { get; set; }
        public string? DisplayName { get;set; }
    }
}
