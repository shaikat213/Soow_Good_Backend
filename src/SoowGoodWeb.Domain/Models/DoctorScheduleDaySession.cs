using SoowGoodWeb.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace SoowGoodWeb.Models
{
    public class DoctorScheduleDaySession : FullAuditedEntity<long>
    {
        public long? DoctorScheduleId { get; set; }
        public DoctorSchedule? DoctorSchedule { get; set; }
        public string? ScheduleDayofWeek { get; set; }
        public string? StartTime { get; set; }
        public string? EndTime { get; set; }
        public int? NoOfPatients { get; set; }
        public bool? IsActive { get; set; }
    }
}
