using SoowGoodWeb.DtoModels;
using SoowGoodWeb.InputDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace SoowGoodWeb.Interfaces
{
    public interface ISpecialityService : IApplicationService
    {
        Task<List<SpecialityDto>> GetListAsync();
        Task<SpecialityDto> GetAsync(int id);
        Task<SpecialityDto> CreateAsync(SpecialityInputDto input);
        Task<SpecialityDto> UpdateAsync(SpecialityInputDto input);
    }
}
