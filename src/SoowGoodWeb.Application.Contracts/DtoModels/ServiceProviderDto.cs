using SoowGoodWeb.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace SoowGoodWeb.DtoModels
{
    public class ServiceProviderDto : FullAuditedEntityDto<long>
    {
        public long? PlatformFacilityId { get; set; }
        public string? PlatformFacilityName { get; set; }
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
