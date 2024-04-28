using SoowGoodWeb.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace SoowGoodWeb.Models
{
    public class DrugRx : FullAuditedEntity<long>
    {
        public string? TradeName { get; set; }
        public string? BrandName { get; set; }
        public string? ProductName { get; set; }
        public string? GenericName { get; set; }
        public string? DosageForm { get; set; }
        public string? Strength { get; set; }
        public DateTime? InclusionDate { get; set; }
        public DateTime? VlidUpto { get; set; }
        public string? Manufacturer { get; set; }
        public string? DAR { get; set; }
        public string? CDAR { get; set; }
        public string? SDAR { get; set; }
        public string? GDAR { get; set; }
    }
}
