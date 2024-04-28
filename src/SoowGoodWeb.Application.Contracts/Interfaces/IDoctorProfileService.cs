using SoowGoodWeb.DtoModels;
using SoowGoodWeb.InputDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace SoowGoodWeb.Interfaces
{
    public interface IDoctorProfileService : IApplicationService
    {
        Task<List<DoctorProfileDto>> GetListAsync();
        Task<DoctorProfileDto> GetAsync(int id);
        Task<DoctorProfileDto> GetByUserNameAsync(string userName);
        Task<DoctorProfileDto> CreateAsync(DoctorProfileInputDto input);
        Task<DoctorProfileDto> UpdateAsync(DoctorProfileInputDto input);
        Task<DoctorProfileDto> GetByUserIdAsync(Guid userId);
    }
}
