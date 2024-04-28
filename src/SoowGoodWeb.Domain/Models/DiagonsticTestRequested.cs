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
    public class DiagonsticTestRequested : FullAuditedEntity<long>
    {
        public long? DiagonsticPathologyServiceManagementId { get; set; }
        public DiagonsticPathologyServiceManagement? DiagonsticPathologyServiceManagement { get; set; }
        public long? DiagonsticTestId { get; set; }
        public DiagonsticTest? DiagonsticTest { get; set; }
        public string? PathologyCategoryAndTest { get;set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? ProviderRate { get; set; }
    }
}
