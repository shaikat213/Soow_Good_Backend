using SoowGoodWeb.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace SoowGoodWeb.InputDto
{
    public class UserDataDeleteRequestInputDto : FullAuditedEntityDto<long>
    {
        public string? FullName { get; set; }
        public string? MobileNumber { get; set; }
        public string? Description { get; set; }
    }
}
