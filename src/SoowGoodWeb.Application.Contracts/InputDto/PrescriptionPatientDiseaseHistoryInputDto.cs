using SoowGoodWeb.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace SoowGoodWeb.InputDto
{
    public class PrescriptionPatientDiseaseHistoryInputDto : FullAuditedEntityDto<long>
    {
        public long? PrescriptionMasterId { get; set; }
        public long? PatientProfileId { get; set; }
        public long? CommonDiseaseId { get; set; }
        public string? DiseaseName { get; set; }
    }
}
