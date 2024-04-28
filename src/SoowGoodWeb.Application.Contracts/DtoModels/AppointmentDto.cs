using SoowGoodWeb.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace SoowGoodWeb.DtoModels
{
    public class AppointmentDto : FullAuditedEntityDto<long>
    {
        public string? AppointmentSerial { get; set; }
        public string? AppointmentCode { get; set; }
        public long? DoctorScheduleId { get; set; }
        //public DoctorScheduleDto? DoctorSchedule { get; set; }
        public string? DoctorScheduleName { get; set; }
        public long? DoctorProfileId { get; set; }
        //public DoctorProfileDto? DoctorProfile { get; set; }
        public string? DoctorName { get; set; }
        public string? DoctorCode { get; set; }
        public long? PatientProfileId { get; set; }
        //public PatientProfileDto? PatientProfile { get; set; }
        public string? PatientName { get; set; }
        public string? PatientCode { get; set; }
        public string? PatientMobileNo { get; set; }
        public string? PatientEmail { get; set; }
        public string? PatientLocation { get; set; }
        public ConsultancyType? ConsultancyType { get; set; }
        public string? ConsultancyTypeName { get; set; }
        public long? DoctorChamberId { get; set; }
        public string? DoctorChamberName { get; set; }
        public long? DoctorScheduleDaySessionId { get; set; }
        //public DoctorScheduleDaySessionDto? DoctorScheduleDaySession { get; set; }
        public string? ScheduleDayofWeek { get; set; }
        public AppointmentType? AppointmentType { get; set; }
        public string? AppointmentTypeName { get; set; }
        public DateTime? AppointmentDate { get; set; }
        public string? AppointmentTime { get; set; }
        public long? DoctorFeesSetupId { get; set; }
        //public DoctorFeesSetupDto? DoctorFeesSetup { get; set; }
        public decimal? DoctorFee { get; set; }
        public decimal? AgentFee { get; set; }
        public decimal? PlatformFee { get; set; }
        public decimal? VatFee { get; set; }
        public decimal? TotalAppointmentFee { get; set; }
        public AppointmentStatus? AppointmentStatus { get; set; }
        public string? AppointmentStatusName { get; set; }
        public AppointmentPaymentStatus? AppointmentPaymentStatus { get; set; }
        public string? AppointmentPaymentStatusName { get; set; }
        public long? CancelledByEntityId { get; set; }
        public string? CancelledByRole { get; set; }
        public string? PaymentTransactionId { get; set; }
        public long? AppointmentCreatorId { get; set; }
        public string? AppointmentCreatorCode { get; set; }
        public string? AppointmentCreatorRole { get; set; }
        public bool? IsCousltationComplete { get; set; }
        public string? CreatorName { get; set; }
        public string? BoothName { get; set; }
        public string? AgentMasterName { get; set; }
        public string? AgentSupervisorName { get; set; }
    }
}
