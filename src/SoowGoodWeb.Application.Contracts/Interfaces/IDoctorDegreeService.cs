using SoowGoodWeb.DtoModels;
using SoowGoodWeb.InputDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace SoowGoodWeb.Interfaces
{
    public interface IDoctorDegreeService : IApplicationService
    {
        Task<List<DoctorDegreeDto>> GetListAsync();
        Task<List<DoctorDegreeDto>> GetDoctorDegreeListByDoctorIdAsync(int doctorId);
        Task<DoctorDegreeDto> GetAsync(int id);
        Task<DoctorDegreeDto> CreateAsync(DoctorDegreeInputDto input);
        Task<DoctorDegreeDto> UpdateAsync(DoctorDegreeInputDto input);
        Task DeleteAsync(long id);
    }
}
