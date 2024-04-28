using SoowGoodWeb.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace SoowGoodWeb.DtoModels
{
    public class DoctorScheduledDayOffDto : FullAuditedEntityDto<long>
    {
        public long? DoctorScheduleId { get; set; }
        public string? DoctorScheduleName { get; set; }
        //public DoctorSchedule? DoctorSchedule { get; set; }
        public string? OffDay { get; set; }
        public bool? IsActive { get; set; }
    }
}
