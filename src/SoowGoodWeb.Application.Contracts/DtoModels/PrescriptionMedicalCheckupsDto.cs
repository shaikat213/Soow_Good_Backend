using SoowGoodWeb.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace SoowGoodWeb.DtoModels
{
    public class PrescriptionMedicalCheckupsDto : FullAuditedEntityDto<long>
    {
        public long? PrescriptionMasterId { get; set; }
        public string? PrescriptionRefferenceCode { get; set; }
        public string? TestName { get; set; }
        public string? Comments { get; set; }
    }
}
