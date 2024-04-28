using SoowGoodWeb.DtoModels;
using SoowGoodWeb.InputDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace SoowGoodWeb.Interfaces
{
    public interface IDiagonsticTestService : IApplicationService
    {
        Task<List<DiagonsticTestDto>> GetListAsync();
        Task<DiagonsticTestDto> GetAsync(int id);
        Task<DiagonsticTestDto> CreateAsync(DiagonsticTestInputDto input);
        Task<DiagonsticTestDto> UpdateAsync(DiagonsticTestInputDto input);
    }
}
