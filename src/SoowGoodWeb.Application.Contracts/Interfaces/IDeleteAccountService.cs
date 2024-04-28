using SoowGoodWeb.DtoModels;
using SoowGoodWeb.InputDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace SoowGoodWeb.Interfaces
{
    public interface IDeleteAccountService : IApplicationService
    {
        Task<List<UserDataDeleteRequestDto>> GetListAsync();
        Task<UserDataDeleteRequestDto> GetAsync(int id);
        Task<UserDataDeleteRequestDto> CreateAsync(UserDataDeleteRequestInputDto input);
        Task<UserDataDeleteRequestDto> UpdateAsync(UserDataDeleteRequestInputDto input);
    }
}
