using SoowGoodWeb.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace SoowGoodWeb.InputDto
{
    public class PrescriptionMainComplaintInputDto : FullAuditedEntityDto<long>
    {
        public long? PrescriptionMasterId { get; set; }
        public string? Symptom { get; set; }
        public string? Duration { get; set; }
        public string? Condition { get; set; }
        public string? Problems { get; set; }
        public string? PhysicianRecommendedAction { get; set; }
    }
}
