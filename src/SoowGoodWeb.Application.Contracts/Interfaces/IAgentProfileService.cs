using SoowGoodWeb.DtoModels;
using SoowGoodWeb.InputDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace SoowGoodWeb.Interfaces
{
    public interface IAgentProfileService : IApplicationService
    {
        Task<List<AgentProfileDto>> GetListAsync();
        Task<AgentProfileDto> GetAsync(int id);
        Task<AgentProfileDto> GetByUserNameAsync(string userName);
        Task<AgentProfileDto> CreateAsync(AgentProfileInputDto input);
        Task<AgentProfileDto> UpdateAsync(AgentProfileInputDto input);
        Task<AgentProfileDto> GetByUserIdAsync(Guid userId);
    }
}
