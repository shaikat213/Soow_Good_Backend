using SoowGoodWeb.Enums;
using Volo.Abp.Application.Dtos;

namespace SoowGoodWeb.DtoModels
{
    public class DocumentsAttachmentDto : FullAuditedEntityDto<long>
    {
        public string? FileName { get; set; }
        public string? OriginalFileName { get; set; }
        public string? Path { get; set; }
        public EntityType? EntityType { get; set; }
        public string? EntityTypeName { get; set; }
        //public int? ImporterId { get; set; }
        public long? EntityId { get; set; }
        public AttachmentType? AttachmentType { get; set; }
        public string? AttachmentTypeName { get; set; }
        public long? RelatedEntityid { get; set; }
    }
}
