using Microsoft.Extensions.DependencyInjection;
using SoowGoodWeb.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace SoowGoodWeb.InputDto
{
    public class DiagonsticPathologyServiceManagementInputDto : FullAuditedEntityDto<long>
    {
        public string? ServiceRequestCode { get; set; }
        public long? ServiceProviderId { get; set; }
        public DiagonsticServiceType? DiagonsticServiceType { get; set; }
        //public long? DiagonsticTestId { get; set; }
        public long? DiagonsticPackageId { get; set; }
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
        public List<DiagonsticTestRequestedInputDto>? DiagonsticTestRequested { get; set; }
    }
}
