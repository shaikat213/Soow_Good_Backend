using Microsoft.Extensions.DependencyInjection;
using SoowGoodWeb.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace SoowGoodWeb.InputDto
{
    public class DiagonsticPackageTestInputDto : FullAuditedEntityDto<long>
    {
        public long? DiagonsticPackageId { get; set; }
        public long? PathologyCategoryId { get; set; }
        public long? PathologyTestId { get; set; }
    }
}
