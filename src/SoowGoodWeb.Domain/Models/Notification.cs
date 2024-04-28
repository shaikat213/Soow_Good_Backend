using SoowGoodWeb.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace SoowGoodWeb.Models
{
    public class Notification : FullAuditedEntity<long>
    {
        public string? Message { get; set; }
        public string? TransactionType { get; set; }        
        public long? CreatorEntityId { get; set;}
        public string? CreatorName { get; set; }
        public string? CreatorRole { get; set; }
        public string? CreateForName { get; set; }
        public long? NotifyToEntityId { get; set; }
        public string? NotifyToName { get; set; }
        public string? NotifyToRole { get; set; }
        public string? NoticeFromEntity { get; set; }
        public long? NoticeFromEntityId { get; set; }
        
    }
}
