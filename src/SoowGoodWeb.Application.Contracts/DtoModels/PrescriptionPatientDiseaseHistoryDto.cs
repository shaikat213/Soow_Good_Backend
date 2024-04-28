using SoowGoodWeb.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace SoowGoodWeb.DtoModels
{
    public class PrescriptionPatientDiseaseHistoryDto : FullAuditedEntityDto<long>
    {
        public long? PrescriptionMasterId { get; set; }
        public string? PrescriptionRefferenceCode { get; set; }
        public long? PatientProfileId { get; set; }
        public string? PatientName { get; set; }
        public long? CommonDiseaseId { get; set; }
        public string? DiseaseName { get; set; }
    }
}
