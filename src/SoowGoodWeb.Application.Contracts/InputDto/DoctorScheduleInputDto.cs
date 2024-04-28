using SoowGoodWeb.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace SoowGoodWeb.DtoModels
{
    public class DoctorScheduleInputDto : FullAuditedEntityDto<long>
    {
        public long? DoctorProfileId { get; set; }
        //public DoctorProfile? DoctorProfile { get; set; }        
        public ScheduleType? ScheduleType { get; set; }        
        public ConsultancyType? ConsultancyType { get; set; }        
        public long? DoctorChamberId { get; set; }
        //public DoctorChamber? DoctorChamber { get; set; }
        //public string? StartTime { get; set; }
        //public string? EndTime { get; set; }
        //public int? NoOfPatients { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? OffDayFrom { get; set; }
        public DateTime? OffDayTo { get; set; }
        public List<DoctorScheduleDaySessionInputDto>? DoctorScheduleDaySession { get; set; }
        public List<DoctorFeesSetupInputDto>? DoctorFeesSetup { get; set; }        
        public string? ScheduleName { get; set; }
    }
}
