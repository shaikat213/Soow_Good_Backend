using SoowGoodWeb.DtoModels;
using SoowGoodWeb.InputDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace SoowGoodWeb.Interfaces
{
    public interface IFinancialSetupService : IApplicationService
    {
        Task<List<FinancialSetupDto>> GetListAsync();
        Task<FinancialSetupDto> GetAsync(int id);
        Task<FinancialSetupDto> CreateAsync(FinancialSetupInputDto input);
        Task<FinancialSetupDto> UpdateAsync(FinancialSetupInputDto input);
        Task DeleteAsync(long id);
    }
}
