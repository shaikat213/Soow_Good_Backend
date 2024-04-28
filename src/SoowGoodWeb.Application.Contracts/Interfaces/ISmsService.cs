using SoowGoodWeb.DtoModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace SoowGoodWeb.Interfaces
{
    public interface ISmsService : IApplicationService
    {
        Task<SmsResponseDto> SendSmsNotification(SmsRequestParamDto input);
        //Task<SmsResponseDto> SendSmsTestAlpha(SmsRequestParamDto input);
        Task<SmsResponseDto> SendSmsGreenWeb(SmsRequestParamDto input);
    }
}
