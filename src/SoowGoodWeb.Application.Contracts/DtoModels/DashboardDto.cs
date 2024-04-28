using SoowGoodWeb.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace SoowGoodWeb.DtoModels
{
    public class DashboardDto
    {
        public long? totalAppointment { get; set; }
        public long? totalPatient { get; set;}
        public decimal? totalFeeAmount { get; set; }
        public decimal? totalPaidAmount { get; set; }
        public decimal? doctorLoyaltypoints { get; set; }
    }
}
