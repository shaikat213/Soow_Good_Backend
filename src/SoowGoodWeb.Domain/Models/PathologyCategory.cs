using SoowGoodWeb.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace SoowGoodWeb.Models
{
    public class PathologyCategory : FullAuditedEntity<long>
    {
        public string? PathologyCategoryName { get; set; }
        public string? PathologyCategoryDescription { get; set; }
    }
}
