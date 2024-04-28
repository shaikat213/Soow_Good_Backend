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
    public class Appointment : FullAuditedEntity<long>
    {
        public string? AppointmentSerial { get; set; }
        public string? AppointmentCode { get; set; }
        public long? DoctorScheduleId { get; set; }
        public DoctorSchedule? DoctorSchedule { get; set; }
        //public string? ScheduleName { get; set; }
        public long? DoctorProfileId { get; set; }
        public string? DoctorCode { get; set; }
        //public DoctorProfile? DoctorProfile { get; set; }             
        public string? DoctorName { get; set; }
        public long? PatientProfileId { get; set; }
        //public PatientProfile? PatientProfile { get; set; }             
        public string? PatientName { get; set; }        
        public string? PatientCode { get; set; }
        public ConsultancyType? ConsultancyType { get; set; }
        public long? DoctorChamberId { get; set; }
        public long? DoctorScheduleDaySessionId { get; set; }
        //public DoctorScheduleDaySession? DoctorScheduleDaySession { get; set; }
        public string? ScheduleDayofWeek { get; set; }
        public AppointmentType? AppointmentType { get; set; }
        public DateTime? AppointmentDate { get; set; }
        public string? AppointmentTime { get; set; }
        public long? DoctorFeesSetupId { get; set; }
        //public DoctorFeesSetup? DoctorFeesSetup { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? DoctorFee { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? AgentFee { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? PlatformFee { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? VatFee { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? TotalAppointmentFee { get; set; }
        public AppointmentStatus? AppointmentStatus { get; set; }
        public AppointmentPaymentStatus? AppointmentPaymentStatus { get; set; }
        public long? CancelledByEntityId { get; set; }
        public string? CancelledByRole { get; set; }
        public string? PaymentTransactionId { get; set; }
        public long? AppointmentCreatorId { get; set; }
        public string? AppointmentCreatorCode { get; set; }
        public string? AppointmentCreatorRole { get; set; }
        public bool? IsCousltationComplete { get; set; }
    }
}
