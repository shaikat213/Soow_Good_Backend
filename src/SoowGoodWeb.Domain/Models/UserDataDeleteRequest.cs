using SoowGoodWeb.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace SoowGoodWeb.Models
{
    public class UserDataDeleteRequest : FullAuditedEntity<long>
    {
        public string? FullName { get; set; }
        public string? MobileNumber { get; set; }
        public string? Description { get; set; }
    }
}
