using SoowGoodWeb.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace SoowGoodWeb.Models
{
    public class PrescriptionPatientDiseaseHistory : FullAuditedEntity<long>
    {
        public long? PrescriptionMasterId { get; set; }
        public PrescriptionMaster? PrescriptionMaster { get; set; }
        public long? PatientProfileId { get; set; }
        public long? CommonDiseaseId { get; set; }
        //public CommonDisease? CommonDisease { get; set; }
        public string? DiseaseName { get; set; }
    }
}
