using SoowGoodWeb.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace SoowGoodWeb.Models
{
    public class ServiceProvider : FullAuditedEntity<long>
    {
        public long? PlatformFacilityId { get;set; }
        public PlatformFacility? PlatformFacility { get;set; }
        public string? ProviderOrganizationName { get; set; }
        public string? OrganizationCode { get; set; }
        public string? ContactPerson { get; set; }        
        public string? ContactPersonMobileNo { get; set; }
        public string? ContactPersonEmail { get; set; }
        public string? Branch { get; set; }
        public string? Address { get; set; }
        public string? OrganizationPhoneNumber { get; set; }
        public string? OrganizationAvailability { get; set; }
        public bool? IsActive { get; set; }
    }
}
