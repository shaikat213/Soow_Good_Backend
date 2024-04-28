using SoowGoodWeb.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace SoowGoodWeb.DtoModels
{
    public class PathologyTestDto : FullAuditedEntityDto<long>
    {
        public long? PathologyCategoryId { get; set; }
        public string? PathologyCategoryName { get; set; }
        public string? PathologyTestName { get; set; }
        public string? PathologyTestDescription { get; set; }
    }
}
