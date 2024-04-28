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
    public class DiagonsticPackageTest : FullAuditedEntity<long>
    {
        public long? DiagonsticPackageId { get; set; }
        public DiagonsticPackage? DiagonsticPackage { get; set; }        
        public long? PathologyCategoryId { get; set; }
        public PathologyCategory? PathologyCategory { get; set; }
        public long? PathologyTestId { get; set; }
        public PathologyTest? PathologyTest { get; set; }
    }
}
