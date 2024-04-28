using SoowGoodWeb.DtoModels;
using SoowGoodWeb.InputDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace SoowGoodWeb.Interfaces
{
    public interface ICommonDiseaseService : IApplicationService
    {
        Task<List<CommonDiseaseDto>> GetListAsync();
        Task<CommonDiseaseDto> GetAsync(int id);
        //Task<DrugRxDto> CreateAsync(DrugRxInputDto input);
        //Task<DrugRxDto> UpdateAsync(DrugRxInputDto input);
    }
}
