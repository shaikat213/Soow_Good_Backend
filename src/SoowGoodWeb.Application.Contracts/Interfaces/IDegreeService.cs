using SoowGoodWeb.DtoModels;
using SoowGoodWeb.InputDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace SoowGoodWeb.Interfaces
{
    public interface IDegreeService : IApplicationService
    {
        Task<List<DegreeDto>> GetListAsync();
        Task<DegreeDto> GetAsync(int id);
        Task<DegreeDto> CreateAsync(DegreeInputDto input);
        Task<DegreeDto> UpdateAsync(DegreeInputDto input);
    }
}
