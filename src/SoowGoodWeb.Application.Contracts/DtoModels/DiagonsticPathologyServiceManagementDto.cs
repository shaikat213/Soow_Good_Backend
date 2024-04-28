using SoowGoodWeb.Enums;
using SoowGoodWeb.InputDto;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace SoowGoodWeb.DtoModels
{
    public class DiagonsticPathologyServiceManagementDto : FullAuditedEntityDto<long>
    {
        public string? ServiceRequestCode { get; set; }
        public long? ServiceProviderId { get; set; }
        public string? ServiceProviderName { get; set; }
        public DiagonsticServiceType? DiagonsticServiceType { get; set; }
        public string? DiagonsticServiceTypeName { get; set; }
        public string? DiagonsticCategoryName { get; set; }
        //public long? DiagonsticTestId { get; set; }
        //public string? DiagonsticTesName { get; set; }
        public long? DiagonsticPackageId { get; set; }
        public string? DiagonsticPackageName { get; set; }
        public string? OrganizationCode { get; set; }
        public long? PatientProfileId { get; set; }
        public string? PatientName { get; set; }
        public string? PatientCode { get; set; }
        public DateTime? RequestDate { get; set; }
        public DateTime? AppointmentDate { get; set; }
        public decimal? ProviderFee { get; set; }
        public decimal? Discount { get; set; }
        public decimal? FinalFee { get; set; }
        public ServiceRequestStatus? ServiceRequestStatus { get; set; }
        public string? ServiceRequestStatusName { get; set; }
        public List<DiagonsticTestRequestedDto>? DiagonsticTestRequested { get; set; }
    }
}
