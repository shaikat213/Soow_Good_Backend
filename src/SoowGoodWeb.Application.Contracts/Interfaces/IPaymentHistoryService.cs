using SoowGoodWeb.DtoModels;
using SoowGoodWeb.InputDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace SoowGoodWeb.Interfaces
{
    public interface IPaymentHistoryService : IApplicationService
    {
        Task<PaymentHistoryDto> GetAsync(int id);
        Task<PaymentHistoryDto> GetByTranIdAsync(string tranId);
        Task<List<PaymentHistoryDto>> GetListAsync();
        Task<PaymentHistoryDto> CreateAsync(PaymentHistoryInputDto input);
        Task<PaymentHistoryDto> UpdateAsync(PaymentHistoryInputDto input);
        Task<bool> UpdateHistoryAsync(PaymentHistoryInputDto input);
    }
}
