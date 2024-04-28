using SoowGoodWeb.DtoModels;
using SoowGoodWeb.InputDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace SoowGoodWeb.Interfaces
{
    public interface IDrugRxService : IApplicationService
    {
        Task<List<DrugRxDto>> GetListAsync();
        Task<DrugRxDto> GetAsync(int id);
        //Task<DrugRxDto> CreateAsync(DrugRxInputDto input);
        //Task<DrugRxDto> UpdateAsync(DrugRxInputDto input);
    }
}
