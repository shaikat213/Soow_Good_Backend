using SoowGoodWeb.DtoModels;
using SoowGoodWeb.InputDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace SoowGoodWeb.Interfaces
{
    public interface IServiceProviderService : IApplicationService
    {
        Task<List<ServiceProviderDto>> GetListAsync();
        Task<ServiceProviderDto> GetAsync(int id);
        Task<ServiceProviderDto> CreateAsync(ServiceProviderInputDto input);
        Task<ServiceProviderDto> UpdateAsync(ServiceProviderInputDto input);
    }
}
