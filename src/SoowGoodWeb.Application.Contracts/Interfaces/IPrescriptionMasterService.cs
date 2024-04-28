using SoowGoodWeb.DtoModels;
using SoowGoodWeb.InputDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace SoowGoodWeb.Interfaces
{
    public interface IPrescriptionMasterService : IApplicationService
    {
        Task<List<PrescriptionMasterDto>> GetListAsync();
        Task<PrescriptionMasterDto> GetAsync(int id);
        Task<PrescriptionMasterDto> CreateAsync(PrescriptionMasterInputDto input);
        Task<PrescriptionMasterDto> UpdateAsync(PrescriptionMasterInputDto input);

        Task<List<PrescriptionPatientDiseaseHistoryDto>> GetPatientDiseaseListAsync(long patientId);

    }
}
