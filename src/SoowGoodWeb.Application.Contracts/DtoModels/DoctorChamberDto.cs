using SoowGoodWeb.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace SoowGoodWeb.DtoModels
{
    public class DoctorChamberDto : FullAuditedEntityDto<long>
    {
        public long? DoctorProfileId { get; set; }
        //public DoctorProfileInputDto? DoctorProfile { get; set; }
        public string? ChamberName { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? ZipCode { get; set; }
        public string? Country { get; set; }
    }
}
