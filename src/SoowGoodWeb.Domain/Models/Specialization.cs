using SoowGoodWeb.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace SoowGoodWeb.Models
{
    public class Specialization : FullAuditedEntity<long>
    {
        public long? SpecialityId { get; set; }
        public Speciality? Speciality { get; set; }
        public string? SpecializationName { get; set; }
        public string? Description { get; set; }
    }
}
