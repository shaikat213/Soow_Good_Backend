using SoowGoodWeb.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace SoowGoodWeb.Models
{
    public class PlatformService : FullAuditedEntity<int>
    {
        public string? ServiceName { get; set; }
        public string? ServiceDescription { get; set; }        

    }
}
