using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace SoowGoodWeb.DtoModels
{
    public class ResponseDto 
    {
        public long? Id { get; set; }
        public string? Value { get; set; }
        public bool? Success { get; set; }
        public string? Message { get; set; }
    }
}
