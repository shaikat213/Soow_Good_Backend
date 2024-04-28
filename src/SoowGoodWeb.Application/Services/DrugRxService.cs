using SoowGoodWeb.DtoModels;
using SoowGoodWeb.Enums;
using SoowGoodWeb.InputDto;
using SoowGoodWeb.Interfaces;
using SoowGoodWeb.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Uow;

namespace SoowGoodWeb.Services
{
    public class DrugRxService : SoowGoodWebAppService, IDrugRxService
    {
        private readonly IRepository<DrugRx> _drugRxRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        public DrugRxService(IRepository<DrugRx> drugRxRepository,
                                         IUnitOfWorkManager unitOfWorkManager)
        {
            _drugRxRepository = drugRxRepository;

            _unitOfWorkManager = unitOfWorkManager;
        }
        public async Task<DrugRxDto> GetAsync(int id)
        {
            var item = await _drugRxRepository.GetAsync(x => x.Id == id);

            return ObjectMapper.Map<DrugRx, DrugRxDto>(item);
        }
        public async Task<List<DrugRxDto>> GetListAsync()
        {
            var degrees = await _drugRxRepository.GetListAsync();
            return ObjectMapper.Map<List<DrugRx>, List<DrugRxDto>>(degrees);
        }

        public async Task<List<DrugRxDto>> GetDrugWithLimitListAsync()
        {
            List<DrugRxDto>? result = null;            
            var item = await _drugRxRepository.WithDetailsAsync();
            var drugs = item.Take(300);//.Where(d => d.BrandName.ToLower().StartsWith(searchDrug)).Take(100).ToList();
            //return ObjectMapper.Map<List<DrugRx>, List<DrugRxDto>>(degrees);


            result = new List<DrugRxDto>();
            foreach (var drug in drugs)
            {
                result.Add(new DrugRxDto()
                {
                    Id = drug.Id,
                    PrescribedDrugName = drug.DosageForm + " " + drug.BrandName

                });
            }
            return result;
        }
        public async Task<List<DrugRxDto>> GetDrugNameSearchListAsync(string? searchDrug=null)
        {
            List<DrugRxDto>? result = null;
            //var dName = searchDrug.ToLower();
            var item = await _drugRxRepository.WithDetailsAsync();
            var drugs = item.Take(100).ToList();
            if(searchDrug!=null)
                drugs = item.Where(d => d.BrandName.ToLower().StartsWith(searchDrug)).Take(100).ToList();
            //return ObjectMapper.Map<List<DrugRx>, List<DrugRxDto>>(degrees);

            result = new List<DrugRxDto>();
            foreach (var drug in drugs)
            {
                result.Add(new DrugRxDto()
                {
                    Id = drug.Id,
                    PrescribedDrugName = drug.DosageForm + " " + drug.BrandName                  

                });
            }
            return result;
        }
    }
}
