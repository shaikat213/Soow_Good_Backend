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
    public class DiagonsticPackage : FullAuditedEntity<long>
    {
        public long? ServiceProviderId { get; set; }
        public ServiceProvider? ServiceProvider  { get; set; }
        public string? PackageName { get; set; }
        public string? PackageDescription { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? ProviderRate { get; set; }
    }
}
