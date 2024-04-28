using SoowGoodWeb.DtoModels;
using SoowGoodWeb.InputDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace SoowGoodWeb.Interfaces
{
    public interface IDiagonsticPackageService : IApplicationService
    {
        Task<List<DiagonsticPackageDto>> GetListAsync();
        Task<DiagonsticPackageDto> GetAsync(int id);
        Task<DiagonsticPackageDto> CreateAsync(DiagonsticPackageInputDto input);
        Task<DiagonsticPackageDto> UpdateAsync(DiagonsticPackageInputDto input);
    }
}
