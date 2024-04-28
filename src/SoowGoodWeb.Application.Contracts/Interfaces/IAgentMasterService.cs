using SoowGoodWeb.DtoModels;
using SoowGoodWeb.InputDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace SoowGoodWeb.Interfaces
{
    public interface IAgentMasterService : IApplicationService
    {
        Task<List<AgentMasterDto>> GetListAsync();
        Task<AgentMasterDto> GetAsync(int id);
        //Task<AgentMasterDto> GetByUserNameAsync(string userName);
        Task<AgentMasterDto> CreateAsync(AgentMasterInputDto input);
        Task<AgentMasterDto> UpdateAsync(AgentMasterInputDto input);
        //Task<AgentMasterDto> GetByUserIdAsync(Guid userId);
    }
}
