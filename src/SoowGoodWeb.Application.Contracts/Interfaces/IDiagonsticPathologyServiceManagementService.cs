using SoowGoodWeb.DtoModels;
using SoowGoodWeb.InputDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace SoowGoodWeb.Interfaces
{
    public interface IDiagonsticPathologyServiceManagementService : IApplicationService
    {
        Task<List<DiagonsticPathologyServiceManagementDto>> GetListAsync();
        Task<DiagonsticPathologyServiceManagementDto> GetAsync(int id);
        Task<DiagonsticPathologyServiceManagementDto> CreateAsync(DiagonsticPathologyServiceManagementInputDto input);
        Task<DiagonsticPathologyServiceManagementDto> UpdateAsync(DiagonsticPathologyServiceManagementInputDto input);
    }
}
