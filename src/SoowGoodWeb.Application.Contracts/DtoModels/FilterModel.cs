using SoowGoodWeb.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace SoowGoodWeb.DtoModels
{
    public class FilterModel
    {
        public int Offset { get; set; }
        public int Limit { get; set; }
        public int PageNo { get; set; }
        public int PageSize { get; set; }
        public string SortBy { get; set; }
        public string SortOrder { get; set; }
        public bool IsDesc { get; set; }
    }

    public class DataFilterModel
    {
        public string? name { get; set; }
        public ConsultancyType? consultancyType { get; set; }
        public long? specialityId { get; set; }
        public long? specializationId { get; set; }        
        public AppointmentStatus? appointmentStatus { get; set; }
        public string? fromDate { get; set; }
        public string? toDate { get; set; }
        public bool? isCurrentOnline { get; set; }
    }
}
