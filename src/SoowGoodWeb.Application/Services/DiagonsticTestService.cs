using SoowGoodWeb.DtoModels;
using SoowGoodWeb.Enums;
using SoowGoodWeb.InputDto;
using SoowGoodWeb.Interfaces;
using SoowGoodWeb.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;
using Volo.Abp.Uow;

namespace SoowGoodWeb.Services
{
    public class DiagonsticTestService : SoowGoodWebAppService, IDiagonsticTestService
    {
        private readonly IRepository<DiagonsticTest> _diagonsticTestRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        private readonly IRepository<FinancialSetup> _financialSetupRepository;

        public DiagonsticTestService(IRepository<DiagonsticTest> diagonsticTestRepository, IRepository<FinancialSetup> financialSetupRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _diagonsticTestRepository = diagonsticTestRepository;
            _financialSetupRepository = financialSetupRepository;

            _unitOfWorkManager = unitOfWorkManager;
        }
        public async Task<DiagonsticTestDto> CreateAsync(DiagonsticTestInputDto input)
        {
            var newEntity = ObjectMapper.Map<DiagonsticTestInputDto, DiagonsticTest>(input);

            var diagonsticTest = await _diagonsticTestRepository.InsertAsync(newEntity);

            await _unitOfWorkManager.Current.SaveChangesAsync();

            return ObjectMapper.Map<DiagonsticTest, DiagonsticTestDto>(diagonsticTest);
        }

        public async Task<DiagonsticTestDto> UpdateAsync(DiagonsticTestInputDto input)
        {
            var updateItem = ObjectMapper.Map<DiagonsticTestInputDto, DiagonsticTest>(input);

            var item = await _diagonsticTestRepository.UpdateAsync(updateItem);

            await _unitOfWorkManager.Current.SaveChangesAsync();

            return ObjectMapper.Map<DiagonsticTest, DiagonsticTestDto>(item);
        }


        public async Task<DiagonsticTestDto> GetAsync(int id)
        {
            var item = await _diagonsticTestRepository.GetAsync(x => x.Id == id);

            return ObjectMapper.Map<DiagonsticTest, DiagonsticTestDto>(item);
        }
        public async Task<List<DiagonsticTestDto>> GetListAsync()
        {
            List<DiagonsticTestDto>? result = null;
            var alldiagonsticTestwithDetails = await _diagonsticTestRepository.WithDetailsAsync(s => s.ServiceProvider, p => p.PathologyCategory, t => t.PathologyTest);
            //var list = allsupervisorwithDetails.ToList();

            if (!alldiagonsticTestwithDetails.Any())
            {
                return result;
            }
            result = new List<DiagonsticTestDto>();
            foreach (var item in alldiagonsticTestwithDetails)
            {
                result.Add(new DiagonsticTestDto()
                {
                    Id = item.Id,
                    ServiceProviderId = item.ServiceProviderId,
                    ServiceProviderName = item.ServiceProviderId > 0 ? item.ServiceProvider?.ProviderOrganizationName : null,
                    PathologyCategoryId = item.PathologyCategoryId,
                    PathologyCategoryName = item.PathologyCategoryId > 0 ? item.PathologyCategory?.PathologyCategoryName : null,
                    PathologyTestId = item.PathologyTestId,
                    PathologyTestName = item.PathologyTestId > 0 ? item.PathologyTest?.PathologyTestName : null,
                    ProviderRate = item.ProviderRate,
                });
            }
            return result;
            //var diagonsticTests = await _diagonsticTestRepository.GetListAsync();
            //return ObjectMapper.Map<List<DiagonsticTest>, List<DiagonsticTestDto>>(diagonsticTests).OrderByDescending(a=>a.Id).ToList();


            //result = result.OrderByDescending(a => a.AppointmentDate).ToList();
            //var list = result.OrderBy(item => item.AppointmentSerial)
            //    .GroupBy(item => item.AppointmentDate)
            //    .OrderBy(g => g.Key).Select(g => new { g }).ToList();


            //return result;
        }

        public async Task<List<DiagonsticTestDto>> GetTestListByProviderIdAsync(long providerId)
        {
            var result = new List<DiagonsticTestDto>();//null;
            //result = new List<DiagonsticTestDto>();
            var alldiagonsticTestwithDetails = await _diagonsticTestRepository.WithDetailsAsync(s => s.ServiceProvider, p => p.PathologyCategory, t => t.PathologyTest);
            var alldiagonsticTests = alldiagonsticTestwithDetails.Where(s => s.ServiceProviderId == providerId).ToList();
            if (!alldiagonsticTests.Any())
            {
                return result;
            }

            foreach (var item in alldiagonsticTests)
            {
                result.Add(new DiagonsticTestDto()
                {
                    Id = item.Id,
                    ServiceProviderId = item.ServiceProviderId,
                    ServiceProviderName = item.ServiceProviderId > 0 ? item.ServiceProvider?.ProviderOrganizationName : null,
                    PathologyCategoryId = item.PathologyCategoryId,
                    PathologyCategoryName = item.PathologyCategoryId > 0 ? item.PathologyCategory?.PathologyCategoryName : null,
                    PathologyTestId = item.PathologyTestId,
                    PathologyTestName = item.PathologyTestId > 0 ? item.PathologyTest?.PathologyTestName : null,
                    ProviderRate = item.ProviderRate
                });
            }
            return result;
        }

        //public async Task<List<DiagonsticTestDto>> GetTestListByProviderIdAsync(long providerId)
        //{
        //    List<DiagonsticTestDto>? result = null;
        //    decimal? totalRate = 0;
        //    var alldiagonsticTestwithDetails = await _diagonsticTestRepository.WithDetailsAsync(s => s.ServiceProvider, p => p.PathologyCategory, t => t.PathologyTest);
        //    var alldiagonsticTests = alldiagonsticTestwithDetails.Where(s => s.ServiceProviderId == providerId);
        //    //var list = allsupervisorwithDetails.ToList();
        //    var finSetup = await _financialSetupRepository.WithDetailsAsync();
        //    if (!alldiagonsticTests.Any())
        //    {
        //        return result;
        //    }
        //    result = new List<DiagonsticTestDto>();
        //    foreach (var item in alldiagonsticTests)
        //    {

        //        decimal? finsetupAmnt = 0;
        //        decimal? discountAmnt = 0;
        //        decimal? finalAmnt = 0;
        //        totalRate = totalRate + item.ProviderRate;
        //        var finsetupAmntIn = finSetup.FirstOrDefault(f => f.PlatformFacilityId == 7 && f.DiagonsticServiceType == DiagonsticServiceType.General)?.AmountIn;
        //        if (finsetupAmntIn == "Percentage")
        //        {
        //            finsetupAmnt = finSetup.FirstOrDefault(a => a.PlatformFacilityId == 7 && a.DiagonsticServiceType == DiagonsticServiceType.General && a.AmountIn == finsetupAmntIn)?.Amount;
        //            discountAmnt = (totalRate * finsetupAmnt) / 100;
        //            finalAmnt = totalRate - discountAmnt;
        //        }
        //        else
        //        {
        //            finsetupAmnt = finSetup.FirstOrDefault(a => a.PlatformFacilityId == 7 && a.DiagonsticServiceType == DiagonsticServiceType.General && a.AmountIn == finsetupAmntIn)?.Amount;
        //            discountAmnt = finsetupAmnt;
        //            finalAmnt = totalRate - discountAmnt;
        //        }
        //        result.Add(new DiagonsticTestDto()
        //        {
        //            Id = item.Id,
        //            ServiceProviderId = item.ServiceProviderId,
        //            ServiceProviderName = item.ServiceProviderId > 0 ? item.ServiceProvider?.ProviderOrganizationName : null,
        //            PathologyCategoryId = item.PathologyCategoryId,
        //            PathologyCategoryName = item.PathologyCategoryId > 0 ? item.PathologyCategory?.PathologyCategoryName : null,
        //            PathologyTestId = item.PathologyTestId,
        //            PathologyTestName = item.PathologyTestId > 0 ? item.PathologyTest?.PathologyTestName : null,
        //            ProviderRate = item.ProviderRate,
        //            TotalProviderRate = totalRate,
        //            DiscountRate = discountAmnt,
        //            FinalRate = finalAmnt
        //        });
        //    }
        //    return result;
        //}
    }
}
