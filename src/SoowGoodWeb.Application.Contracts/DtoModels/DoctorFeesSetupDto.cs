using SoowGoodWeb.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace SoowGoodWeb.DtoModels
{
    public class DoctorFeesSetupDto : FullAuditedEntityDto<long>
    {
        public long? DoctorScheduleId { get; set; }
        //public DoctorSchedule? DoctorSchedule { get; set; }
        public string? DoctorScheduleName { get; set; }
        public AppointmentType? AppointmentType { get; set; }
        public string? AppointmentTypeName { get; set; }
        public decimal? CurrentFee { get; set; }
        public decimal? PreviousFee { get; set; }
        public DateTime? FeeAppliedFrom { get; set; }
        public int? FollowUpPeriod { get; set; }
        public int? ReportShowPeriod { get; set; }
        public decimal? Discount { get; set; }
        public DateTime? DiscountAppliedFrom { get; set; }
        public int? DiscountPeriod { get; set; }
        public decimal? TotalFee { get; set; }
        public bool? IsActive { get; set; }
        public bool? ResponseSuccess { get; set; }
        public string? ResponseMessage { get; set; }
    }
}
