using SoowGoodWeb.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace SoowGoodWeb.Models
{
    public class PrescriptionDrugDetails : FullAuditedEntity<long>
    {
        public long? PrescriptionMasterId { get; set; }
        public PrescriptionMaster? PrescriptionMaster { get; set; }
        public long? DrugRxId { get; set; }
        //public DrugRx? DrugRx { get; set; }
        public string? DrugName { get; set; }
        public string? DrugDoseSchedule { get; set; }
        public bool? IsDrugExceptional { get; set; }
        public string? DrugDoseScheduleDays { get; set; } // if IsDrugExceptional is true
        public string? Duration { get; set; }        
        public string? Instruction { get; set; }
    }
}
