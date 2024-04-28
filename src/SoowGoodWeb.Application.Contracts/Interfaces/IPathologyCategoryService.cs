using SoowGoodWeb.DtoModels;
using SoowGoodWeb.InputDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace SoowGoodWeb.Interfaces
{
    public interface IPathologyCategoryService : IApplicationService
    {
        Task<List<PathologyCategoryDto>> GetListAsync();
        Task<PathologyCategoryDto> GetAsync(int id);
        Task<PathologyCategoryDto> CreateAsync(PathologyCategoryInputDto input);
        Task<PathologyCategoryDto> UpdateAsync(PathologyCategoryInputDto input);
    }
}
