using SoowGoodWeb.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace SoowGoodWeb.InputDto
{
    public class PathologyTestInputDto : FullAuditedEntityDto<long>
    {
        public long? PathologyCategoryId { get; set; }
        public string? PathologyTestName { get; set; }
        public string? PathologyTestDescription { get; set; }
    }
}
