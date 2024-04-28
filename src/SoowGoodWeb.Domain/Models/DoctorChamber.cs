using SoowGoodWeb.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace SoowGoodWeb.Models
{
    public class DoctorChamber : FullAuditedEntity<long>
    {
        public long? DoctorProfileId { get; set; }
        public DoctorProfile? DoctorProfile { get; set; }        
        public string? ChamberName { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? ZipCode { get; set; }        
        public string? Country { get; set; }
    }
}
