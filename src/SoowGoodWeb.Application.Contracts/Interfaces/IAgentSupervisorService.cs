using SoowGoodWeb.DtoModels;
using SoowGoodWeb.InputDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace SoowGoodWeb.Interfaces
{
    public interface IAgentSupervisorService : IApplicationService
    {
        Task<List<AgentSupervisorDto>> GetListAsync();
        Task<AgentSupervisorDto> GetAsync(int id);
        //Task<AgentSupervisorDto> GetByUserNameAsync(string userName);
        Task<AgentSupervisorDto> CreateAsync(AgentSupervisorInputDto input);
        Task<AgentSupervisorDto> UpdateAsync(AgentSupervisorInputDto input);
        //Task<AgentSupervisorDto> GetByUserIdAsync(Guid userId);
    }
}
