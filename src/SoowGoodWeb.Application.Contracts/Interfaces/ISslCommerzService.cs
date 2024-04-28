using SoowGoodWeb.DtoModels;
using SoowGoodWeb.InputDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace SoowGoodWeb.Interfaces
{
    public interface ISslCommerzService : IApplicationService
    {
        // For Live
        Task<bool> InitiateRefundAsync();
        Task<SslCommerzInitDto> InitiatePaymentAsync(SslCommerzInputDto input);
        Task<TransactionValidationDto> ValidateTransactionAsync(Dictionary<string, string> responseDic);

        // For Sandbox
        Task<bool> InitiateTestRefundAsync();
        Task<SslCommerzInitDto> InitiateTestPaymentAsync(SslCommerzInputDto input);
        Task<TransactionValidationDto> ValidateTestTransactionAsync(Dictionary<string, string> responseDic);

        Task UpdatePaymentHistory(Dictionary<string, string> sslCommerzResponseDic);
        Task UpdateApplicantPaymentStatus(Dictionary<string, string> sslCommerzResponseDic);
    }
}
