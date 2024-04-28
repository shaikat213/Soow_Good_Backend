using SoowGoodWeb.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace SoowGoodWeb.InputDto
{
    public class PrescriptionDrugDetailsInputDto : FullAuditedEntityDto<long>
    {
        public long? PrescriptionMasterId { get; set; }
        public long? DrugRxId { get; set; }
        public string? DrugName { get; set; }
        public string? DrugDoseSchedule { get; set; }
        public bool? IsDrugExceptional { get; set; }
        public string? DrugDoseScheduleDays { get; set; } // if IsDrugExceptional is true
        public string? Duration { get; set; }
        public string? Instruction { get; set; }

    }
}
