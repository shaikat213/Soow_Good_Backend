using SoowGoodWeb.DtoModels;
using SoowGoodWeb.InputDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace SoowGoodWeb.Interfaces
{
    public interface IDoctorScheduleDaySessionService : IApplicationService
    {
        Task<List<DoctorScheduleDaySessionDto>> GetSessionListAsync();
        Task<DoctorScheduleDaySessionDto> GetSessionAsync(int id);
        Task<ResponseDto> CreateSessionAsync(DoctorScheduleDaySessionInputDto input);
        Task<ResponseDto> UpdateSessionAsync(DoctorScheduleDaySessionInputDto input);

        //Task<List<DoctorScheduledDayOffDto>> GetDayOffsListAsync();
        //Task<DoctorScheduledDayOffDto> GetDayOffsAsync(int id);
        //Task<DoctorScheduledDayOffDto> CreateDayOffAsync(DoctorScheduledDayOffInputDto input);
        //Task<DoctorScheduledDayOffDto> UpdateDayOffAsync(DoctorScheduledDayOffInputDto input);
        //Task<DoctorScheduleDto> GetByUserIdAsync(long doctorId);
    }
}
