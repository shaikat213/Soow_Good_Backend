using SoowGoodWeb.DtoModels;
using SoowGoodWeb.InputDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace SoowGoodWeb.Interfaces
{
    public interface IDoctorSpecializationService : IApplicationService
    {
        Task<List<DoctorSpecializationDto>> GetListAsync();
        Task<DoctorSpecializationDto> GetAsync(int id);
        Task<DoctorSpecializationDto> GetBySpecialityIdAsync(int specialityId);
        Task<List<DoctorSpecializationDto>> GetDoctorSpecializationListBySpecialityIdAsync(int specialityId);
        Task<List<DoctorSpecializationDto>> GetDoctorSpecializationListByDoctorIdAsync(int doctorId);
        Task<List<DoctorSpecializationDto>> GetDoctorSpecializationListByDoctorIdSpecialityIdAsync(int doctorId, int specialityId);
        Task<DoctorSpecializationDto> CreateAsync(DoctorSpecializationInputDto input);
        Task<DoctorSpecializationDto> UpdateAsync(DoctorSpecializationInputDto input);
        Task DeleteAsync(long id);

    }
}
