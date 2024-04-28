using SoowGoodWeb.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace SoowGoodWeb.DtoModels
{
    public class DrugRxDto : FullAuditedEntityDto<long>
    {
        public string? TradeName { get; set; }
        public string? BrandName { get; set; }
        public string? ProductName { get; set; }
        public string? GenericName { get; set; }
        public string? DosageForm { get; set; }
        public string? Strength { get; set; }
        public DateTime? InclusionDate { get; set; }
        public DateTime? VlidUpto { get; set; }
        public string? Manufacturer { get; set; }
        public string? DAR { get; set; }
        public string? CDAR { get; set; }
        public string? SDAR { get; set; }
        public string? GDAR { get; set; }
        public string? PrescribedDrugName { get; set; }

    }
}
