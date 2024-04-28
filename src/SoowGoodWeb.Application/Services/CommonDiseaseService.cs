using SoowGoodWeb.DtoModels;
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
    public class CommonDiseaseService : SoowGoodWebAppService, ICommonDiseaseService
    {
        private readonly IRepository<CommonDisease> _commonDiseaseRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        public CommonDiseaseService(IRepository<CommonDisease> commonDiseaseRepository,
                                         IUnitOfWorkManager unitOfWorkManager)
        {
            _commonDiseaseRepository = commonDiseaseRepository;

            _unitOfWorkManager = unitOfWorkManager;
        }

        public async Task<CommonDiseaseDto> GetAsync(int id)
        {
            var item = await _commonDiseaseRepository.GetAsync(x => x.Id == id);

            return ObjectMapper.Map<CommonDisease, CommonDiseaseDto>(item);
        }
        public async Task<List<CommonDiseaseDto>> GetListAsync()
        {
            var degrees = await _commonDiseaseRepository.GetListAsync();
            return ObjectMapper.Map<List<CommonDisease>, List<CommonDiseaseDto>>(degrees);
        }

        public async Task<List<CommonDiseaseDto>> GetDiseaseNameWithLimitListAsync()
        {
            List<CommonDiseaseDto>? result = null;
            var item = await _commonDiseaseRepository.WithDetailsAsync();
            var diseases = item.Take(150);
            //return ObjectMapper.Map<List<DrugRx>, List<DrugRxDto>>(degrees);


            result = new List<CommonDiseaseDto>();
            foreach (var disease in diseases)
            {
                result.Add(new CommonDiseaseDto()
                {
                    Id = disease.Id,
                    Name = disease.Name

                });
            }
            return result;
        }

        public async Task<List<CommonDiseaseDto>> GetDiseaseNameSearchListAsync(string? searchDisease=null)
        {
            List<CommonDiseaseDto>? result = null;
            //var dName = searchDisease.ToLower();
            var item = await _commonDiseaseRepository.WithDetailsAsync();
            var diseases = item.Take(100).ToList();
            if(searchDisease != null)
                diseases = item.Where(d => d.Name.ToLower().StartsWith(searchDisease)).Take(100).ToList();
            
            result = new List<CommonDiseaseDto>();
            foreach (var disease in diseases)
            {
                result.Add(new CommonDiseaseDto()
                {
                    Id = disease.Id,
                    Name = disease.Name

                });
            }
            return result;
        }
    }
}
