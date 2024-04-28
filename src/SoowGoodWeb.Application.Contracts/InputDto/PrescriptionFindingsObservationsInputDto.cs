using SoowGoodWeb.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace SoowGoodWeb.InputDto
{
    public class PrescriptionFindingsObservationsInputDto : FullAuditedEntityDto<long>
    {
        public long? PrescriptionMasterId { get; set; }
        public string? Observation { get; set; }
        public string? Comments { get; set; }
    }
}
