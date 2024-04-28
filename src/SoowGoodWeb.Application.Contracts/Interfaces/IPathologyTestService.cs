using SoowGoodWeb.DtoModels;
using SoowGoodWeb.InputDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace SoowGoodWeb.Interfaces
{
    public interface IPathologyTestService : IApplicationService
    {
        Task<List<PathologyTestDto>> GetListAsync();
        Task<PathologyTestDto> GetAsync(int id);
        Task<PathologyTestDto> CreateAsync(PathologyTestInputDto input);
        Task<PathologyTestDto> UpdateAsync(PathologyTestInputDto input);
    }
}
