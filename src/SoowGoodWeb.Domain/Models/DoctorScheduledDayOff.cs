using SoowGoodWeb.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace SoowGoodWeb.Models
{
    public class DoctorScheduledDayOff : FullAuditedEntity<long>
    {
        public long? DoctorScheduleId { get; set; }
        public DoctorSchedule? DoctorSchedule { get; set; }
        public string? OffDay { get; set; }
        public bool? IsActive { get; set; }
    }
}
