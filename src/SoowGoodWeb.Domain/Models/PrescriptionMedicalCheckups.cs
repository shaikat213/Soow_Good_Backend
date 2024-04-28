using SoowGoodWeb.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace SoowGoodWeb.Models
{
    public class PrescriptionMedicalCheckups : FullAuditedEntity<long>
    {
        public long? PrescriptionMasterId { get; set; }
        public PrescriptionMaster? PrescriptionMaster { get; set; }
        public string? TestName { get; set; }
        public string? Comments { get; set; }
    }
}
