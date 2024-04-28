using SoowGoodWeb.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace SoowGoodWeb.Models
{
    public class DocumentsAttachment : FullAuditedEntity<long>
    {
        public string? FileName { get; set; }
        public string? OriginalFileName { get; set; }
        public string? Path { get; set; }
        public EntityType? EntityType { get; set; }
        public long? EntityId { get; set; }
        public AttachmentType? AttachmentType { get; set; }
        public long? RelatedEntityid { get; set; }
    }
}
