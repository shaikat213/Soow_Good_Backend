using SoowGoodWeb.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace SoowGoodWeb.Models
{
    public class DoctorFeesSetup : FullAuditedEntity<long>
    {
        public long? DoctorScheduleId { get; set; }
        public DoctorSchedule? DoctorSchedule { get; set; }
        public AppointmentType? AppointmentType { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? CurrentFee { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? PreviousFee { get; set; }
        public DateTime? FeeAppliedFrom { get; set; }
        public int? FollowUpPeriod { get; set; }
        public int? ReportShowPeriod { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? Discount { get; set; }
        public DateTime? DiscountAppliedFrom { get; set; }
        public int? DiscountPeriod { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? TotalFee { get; set; }
        public bool? IsActive { get; set; }
    }
}
