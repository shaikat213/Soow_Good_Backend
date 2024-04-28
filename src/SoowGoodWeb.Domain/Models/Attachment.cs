using SoowGoodWeb.Enums;
using Volo.Abp.Domain.Entities.Auditing;

namespace SoowGoodWeb.Models
{
    public class Attachment : FullAuditedEntity<long>
    {
        public string? FileName { get; set; }
        public string? OriginalFileName { get; set; }
        public string? Path { get; set; }
        public EntityType? EntityType { get; set; }
        public long? EntityId { get; set; }
        public AttachmentType AttachmentType { get; set; }

    }

}
