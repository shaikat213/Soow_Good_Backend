using SoowGoodWeb.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace SoowGoodWeb.Models
{
    public class DiagonsticPathologyServiceManagement : FullAuditedEntity<long>
    {
        public string? ServiceRequestCode { get; set; }
        public long? ServiceProviderId { get; set; }
        public ServiceProvider? ServiceProvider { get; set; }
        public DiagonsticServiceType? DiagonsticServiceType { get; set; }
        //public long? DiagonsticTestId { get; set; }
        //public DiagonsticTest? DiagonsticTest { get; set; }
        public long? DiagonsticPackageId { get; set; }
        public DiagonsticPackage? DiagonsticPackage { get; set; }
        public string? OrganizationCode { get; set; }
        public long? PatientProfileId { get; set; }
        public string? PatientName { get; set; }        
        public string? PatientCode { get; set; }
        public DateTime? RequestDate { get; set; }
        public DateTime? AppointmentDate { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? ProviderFee { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? Discount { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? FinalFee { get; set; }
        public ServiceRequestStatus? ServiceRequestStatus { get; set; }
        public List<DiagonsticTestRequested>? DiagonsticTestRequested { get; set; }
    }
}
