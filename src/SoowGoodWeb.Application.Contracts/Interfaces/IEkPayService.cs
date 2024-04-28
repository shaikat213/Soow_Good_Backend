using SoowGoodWeb.DtoModels;
using SoowGoodWeb.InputDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace SoowGoodWeb.Interfaces
{
    public interface IEkPayService : IApplicationService
    {
        // For Live
        //Task<bool> InitiateRefundAsync();
        Task<EkPayInitDto> InitiatePaymentAsync(EkPayInputDto input);
        //Task<TransactionValidationDto> ValidateTransactionAsync(Dictionary<string, string> responseDic);

        // For Sandbox
        //Task<bool> InitiateTestRefundAsync();
        Task<EkPayInitDto> InitiateTestPaymentAsync(EkPayInputDto input);
        //Task<TransactionValidationDto> ValidateTestTransactionAsync(Dictionary<string, string> responseDic);

        Task UpdatePaymentHistory(Dictionary<string, string> sslCommerzResponseDic);
        Task UpdateApplicantPaymentStatus(Dictionary<string, string> sslCommerzResponseDic);
    }
}
