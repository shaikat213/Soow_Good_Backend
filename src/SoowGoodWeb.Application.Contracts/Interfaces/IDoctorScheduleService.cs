using SoowGoodWeb.DtoModels;
using SoowGoodWeb.InputDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace SoowGoodWeb.Interfaces
{
    public interface IDoctorScheduleService : IApplicationService
    {
        Task<List<DoctorScheduleDto>> GetListAsync();
        Task<DoctorScheduleDto?> GetAsync(int id);
        Task<ResponseDto> CreateAsync(DoctorScheduleInputDto input);
        Task<ResponseDto> UpdateAsync(DoctorScheduleInputDto input);
        Task<DoctorScheduleDto> CreateFromMobileAppAsync(DoctorScheduleInputDto input);
        Task<DoctorScheduleDto> UpdateFromMobileAppAsync(DoctorScheduleInputDto input);

        //Task<List<DoctorScheduleDaySessionDto>> GetSessionListAsync();
        //Task<DoctorScheduleDaySessionDto> GetSessionAsync(int id);
        //Task<ResponseDto> CreateSessionAsync(DoctorScheduleDaySessionInputDto input);
        //Task<ResponseDto> UpdateSessionAsync(DoctorScheduleDaySessionInputDto input);
        //Task<ResponseDto> DeleteSessionAsync(long id);

        //Task<List<DoctorScheduledDayOffDto>> GetDayOffsListAsync();
        //Task<DoctorScheduledDayOffDto> GetDayOffsAsync(int id);
        //Task<DoctorScheduledDayOffDto> CreateDayOffAsync(DoctorScheduledDayOffInputDto input);
        //Task<DoctorScheduledDayOffDto> UpdateDayOffAsync(DoctorScheduledDayOffInputDto input);
        //Task<DoctorScheduleDto> GetByUserIdAsync(long doctorId);
    }
}
