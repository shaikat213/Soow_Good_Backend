using SoowGoodWeb.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace SoowGoodWeb.Models
{
    public class Speciality : FullAuditedEntity<long>
    {
        public string? SpecialityName { get; set; }
        public string? Description { get; set; }
        public List<Specialization>? Specializations { get; set; }
    }
}
