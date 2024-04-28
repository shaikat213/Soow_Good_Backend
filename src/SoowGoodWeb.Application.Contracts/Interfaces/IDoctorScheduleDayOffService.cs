using SoowGoodWeb.DtoModels;
using SoowGoodWeb.InputDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace SoowGoodWeb.Interfaces
{
    public interface IDoctorScheduleDayOffService : IApplicationService
    {
        Task<List<DoctorScheduledDayOffDto>> GetListAsync();
        Task<DoctorScheduledDayOffDto> GetAsync(int id);
        Task<DoctorScheduledDayOffDto> CreateAsync(DoctorScheduledDayOffInputDto input);
        Task<DoctorScheduledDayOffDto> UpdateAsync(DoctorScheduledDayOffInputDto input);
        //Task<DoctorScheduleDto> GetByUserIdAsync(long doctorId);
    }
}
