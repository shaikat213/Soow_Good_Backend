using SoowGoodWeb.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace SoowGoodWeb.DtoModels
{
    public class PathologyCategoryDto : FullAuditedEntityDto<long>
    {
        public string? PathologyCategoryName { get; set; }
        public string? PathologyCategoryDescription { get; set; }
    }
}
