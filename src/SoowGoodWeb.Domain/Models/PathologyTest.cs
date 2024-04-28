using SoowGoodWeb.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace SoowGoodWeb.Models
{
    public class PathologyTest : FullAuditedEntity<long>
    {
        public long? PathologyCategoryId { get; set; }
        public PathologyCategory? PathologyCategory { get; set; }
        public string? PathologyTestName { get; set; }
        public string? PathologyTestDescription { get; set; }
    }
}
