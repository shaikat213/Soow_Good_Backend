using SoowGoodWeb.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace SoowGoodWeb.Models
{
    public class PlatformFacility : FullAuditedEntity<long>
    {
        public string? ServiceName { get; set; }
        public string? Description { get; set; }
        public string? Slug { get; set; }
    }
}
