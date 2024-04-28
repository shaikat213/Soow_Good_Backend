using SoowGoodWeb.DtoModels;
using SoowGoodWeb.InputDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace SoowGoodWeb.Interfaces
{
    public interface IPatientProfileService : IApplicationService
    {
        Task<List<PatientProfileDto>> GetListAsync();
        Task<PatientProfileDto> GetAsync(long id);
        Task<PatientProfileDto> GetByUserNameAsync(string userName);
        Task<PatientProfileDto> CreateAsync(PatientProfileInputDto input);
        Task<PatientProfileDto> UpdateAsync(PatientProfileInputDto input);
    }
}
