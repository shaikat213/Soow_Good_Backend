using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Linq;

namespace SoowGoodWeb.Enums
{
    public enum OtpStatus
    {
        New = 0,
        Send = 1,
        Varified = 2,
        Cancel = 3,
        TimeExpired = 4,
    }
    public enum Gender
    {
        Male = 1,
        Female = 2,
        Others = 3
    }
    public enum MaritalStatus
    {
        Single = 1,
        Maried = 2
    }
    public enum DoctorTitle
    {
        [Display(Name = "Dr.")]
        Dr = 1,
        [Display(Name = "Asst. Prof. Dr.")]
        AsstProfDr = 2,
        [Display(Name = "Assc. Prof. Dr.")]
        AssocProfDr = 3,
        [Display(Name = "Prof. Dr.")]
        ProfDr = 4
    }
    //Document Attachment
    public enum EntityType
    {
        //None = 0,
        Doctor = 1,
        Agent = 2,
        Patient = 3,
        Hospital = 4
    }
    public enum AttachmentType
    {
        ProfilePicture = 1,
        DoctorDegreeDoc = 2,
        DoctIdentityDoc = 3,
        DoctorSpecialityDoc = 4,
        Prescription = 5,
        PatientPreviousDocuments = 6,
    }

    public enum ScheduleType
    {
        //None = 0,
        Regular = 1,
        Occasional = 2
    }
    public enum ConsultancyType
    {
        //None = 0,
        Chamber = 1,
        Online = 2,
        //PhysicalVisit = 3,
        //OnDemand = 4,
        Instant = 5        //Online Real Time
    }

    public enum AppointmentType
    {
        New = 1,
        Followup = 2,
        ReportShow = 3,
        Emargency = 4
    }

    public enum AppointmentStatus
    {
        Pending = 1,
        Confirmed = 2,
        InProgress = 3,
        Completed = 4,
        Cancelled = 5,
        Failed = 6
    }
    public enum AppointmentPaymentStatus
    {
        Paid = 1,
        Due = 2,
        FailedOrCancelled = 3

    }


    // Payment SSLCommerze

    public enum RefundStatus
    {
        INVALID_REQUEST,
        FAILED,
        INACTIVE,
        DONE
    }

    public enum ResponseStatus
    {
        VALID,
        FAILED,
        CANCELLED,
        UNATTEMPTED,
        EXPIRED
    }

    public enum SecurityStatus
    {
        VALID,
        FAILED,
        CANCEL
    }

    public enum ValidationStatus
    {
        VALID,
        VALIDATED,
        INVALID_TRANSACTION
    }

    public enum ServiceRequestStatus
    {
        ReauestSubmited = 1,
        RequestRecieved = 2,
        RequestConfirmed = 3,
        ServiceRecieved = 4,
        Cancelled = 5
    }

    public enum DiagonsticServiceType
    {
        General = 1,
        Package = 2
    }

    public enum FacilityEntityType
    {
        DoctorConsultation = 1,
        ServiceFacility = 2
    }
}
