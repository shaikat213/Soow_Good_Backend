using SoowGoodWeb.DtoModels;
using SoowGoodWeb.InputDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace SoowGoodWeb.Interfaces
{
    public interface ISpecializationService : IApplicationService
    {
        Task<List<SpecializationDto>> GetListAsync();
        Task<SpecializationDto> GetAsync(int id);
        Task<SpecializationDto> GetBySpecialityIdAsync(int specialityId);
        Task<SpecializationDto> CreateAsync(SpecializationInputDto input);
        Task<SpecializationDto> UpdateAsync(SpecializationInputDto input);
    }
}
