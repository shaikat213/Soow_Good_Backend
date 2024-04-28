using SoowGoodWeb.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace SoowGoodWeb.Models
{
    public class DoctorSchedule : FullAuditedEntity<long>
    {
        public string? ScheduleName { get;set; }
        public long? DoctorProfileId { get; set; }
        public DoctorProfile? DoctorProfile { get; set; }             
        public ScheduleType? ScheduleType { get; set; }
        public ConsultancyType? ConsultancyType { get; set; }
        public long? DoctorChamberId { get; set; }
        public DoctorChamber? DoctorChamber { get; set; }            
        public bool? IsActive { get; set; }
        public DateTime? OffDayFrom { get; set; }
        public DateTime? OffDayTo { get;set; }
        public List<DoctorScheduleDaySession>? DoctorScheduleDaySession { get; set; }
        public List<DoctorFeesSetup>? DoctorFeesSetup { get; set; }
        public List<Appointment>? Appointments { get; set; }
    }
}
