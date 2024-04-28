using SoowGoodWeb.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace SoowGoodWeb.Models
{
    public class CommonDisease : FullAuditedEntity<long>
    {
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
