using SoowGoodWeb.DtoModels;
using SoowGoodWeb.InputDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace SoowGoodWeb.Interfaces
{
    public interface IDoctorChamberService : IApplicationService
    {
        Task<List<DoctorChamberDto>> GetListAsync();
        Task<List<DoctorChamberDto>> GetDoctorChamberListByDoctorIdAsync(int doctorId);
        Task<DoctorChamberDto> GetAsync(int id);
        Task<DoctorChamberDto> CreateAsync(DoctorChamberInputDto input);
        Task<DoctorChamberDto> UpdateAsync(DoctorChamberInputDto input);
    }
}
