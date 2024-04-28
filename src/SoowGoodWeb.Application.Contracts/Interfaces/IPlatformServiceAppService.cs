using SoowGoodWeb.DtoModels;
using SoowGoodWeb.InputDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace SoowGoodWeb.Interfaces
{
    public interface IPlatformServiceAppService : IApplicationService
    {
        Task<List<PlatformServiceDto>> GetListAsync();
        Task<PlatformServiceDto> GetAsync(int id);
        Task<PlatformServiceDto> CreateAsync(PlatformServiceInputDto input);
        Task<PlatformServiceDto> UpdateAsync(PlatformServiceInputDto input);
    }
}
