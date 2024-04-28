using SoowGoodWeb.DtoModels;
using SoowGoodWeb.InputDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace SoowGoodWeb.Interfaces
{
    public interface IPlatformFacilityService : IApplicationService
    {
        Task<List<PlatformFacilityDto>> GetListAsync();
        Task<PlatformFacilityDto> GetAsync(int id);
        Task<PlatformFacilityDto> CreateAsync(PlatformFacilityInputDto input);
        Task<PlatformFacilityDto> UpdateAsync(PlatformFacilityInputDto input);
    }
}
