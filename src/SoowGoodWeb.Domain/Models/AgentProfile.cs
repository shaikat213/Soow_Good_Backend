using SoowGoodWeb.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace SoowGoodWeb.Models
{
    public class AgentProfile : FullAuditedEntity<long>
    {
        public long? AgentMasterId { get; set; }
        public AgentMaster? AgentMaster { get; set; }
        public long? AgentSupervisorId { get; set; }
        public AgentSupervisor? AgentSupervisor { get; set; }
        public string? FullName { get; set; }
        public string? AgentCode { get; set; }
        public string? OrganizationName { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? ZipCode { get; set; }        
        public string? Country { get; set; }
        public string? MobileNo { get; set; }
        public string? Email { get; set; }
        public bool? IsActive { get; set; }
        public Guid? UserId { get; set; }
        public int? profileStep { get; set;}
        public string? createFrom { get; set; }
        public string? AgentDocNumber { get; set; } //BIN, TIN, TL Etc
        public DateTime? AgentDocExpireDate { get; set; }

    }
}
