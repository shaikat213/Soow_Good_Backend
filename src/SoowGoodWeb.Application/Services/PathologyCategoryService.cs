using SoowGoodWeb.DtoModels;
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
    public class PathologyCategoryService : SoowGoodWebAppService, IPathologyCategoryService
    {
        private readonly IRepository<PathologyCategory> _pathologyCategoryRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        private readonly IRepository<DoctorProfile> _doctorProfileRepository;

        public PathologyCategoryService(IRepository<PathologyCategory> pathologyCategoryRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _pathologyCategoryRepository = pathologyCategoryRepository;

            _unitOfWorkManager = unitOfWorkManager;
        }
        public async Task<PathologyCategoryDto> CreateAsync(PathologyCategoryInputDto input)
        {
            var newEntity = ObjectMapper.Map<PathologyCategoryInputDto, PathologyCategory>(input);

            var pathologyCategory = await _pathologyCategoryRepository.InsertAsync(newEntity);

            await _unitOfWorkManager.Current.SaveChangesAsync();

            return ObjectMapper.Map<PathologyCategory, PathologyCategoryDto>(pathologyCategory);
        }

        public async Task<PathologyCategoryDto> UpdateAsync(PathologyCategoryInputDto input)
        {
            var updateItem = ObjectMapper.Map<PathologyCategoryInputDto, PathologyCategory>(input);

            var item = await _pathologyCategoryRepository.UpdateAsync(updateItem);

            await _unitOfWorkManager.Current.SaveChangesAsync();

            return ObjectMapper.Map<PathologyCategory, PathologyCategoryDto>(item);
        }


        public async Task<PathologyCategoryDto> GetAsync(int id)
        {
            var item = await _pathologyCategoryRepository.GetAsync(x => x.Id == id);

            return ObjectMapper.Map<PathologyCategory, PathologyCategoryDto>(item);
        }
        public async Task<List<PathologyCategoryDto>> GetListAsync()
        {
            var pathologyCategorys = await _pathologyCategoryRepository.GetListAsync();
            return ObjectMapper.Map<List<PathologyCategory>, List<PathologyCategoryDto>>(pathologyCategorys).OrderByDescending(a=>a.Id).ToList();


            //result = result.OrderByDescending(a => a.AppointmentDate).ToList();
            //var list = result.OrderBy(item => item.AppointmentSerial)
            //    .GroupBy(item => item.AppointmentDate)
            //    .OrderBy(g => g.Key).Select(g => new { g }).ToList();


            //return result;
        }
    }
}
