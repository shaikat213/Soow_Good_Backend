using SoowGoodWeb.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace SoowGoodWeb.Models
{
    public class PrescriptionMainComplaint : FullAuditedEntity<long>
    {
        public long? PrescriptionMasterId { get; set; }
        public PrescriptionMaster? PrescriptionMaster { get; set; }
        public string? Symptom { get; set; }
        public string? Duration { get; set; }
        public string? Condition { get; set; }
        public string? Problems { get; set; }
        public string? PhysicianRecommendedAction { get; set; }
    }
}
