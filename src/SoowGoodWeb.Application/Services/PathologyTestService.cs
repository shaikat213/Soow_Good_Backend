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
    public class PathologyTestService : SoowGoodWebAppService, IPathologyTestService
    {
        private readonly IRepository<PathologyTest> _pathologyTestRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        private readonly IRepository<DoctorProfile> _doctorProfileRepository;

        public PathologyTestService(IRepository<PathologyTest> pathologyTestRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _pathologyTestRepository = pathologyTestRepository;

            _unitOfWorkManager = unitOfWorkManager;
        }
        public async Task<PathologyTestDto> CreateAsync(PathologyTestInputDto input)
        {
            var newEntity = ObjectMapper.Map<PathologyTestInputDto, PathologyTest>(input);

            var pathologyTest = await _pathologyTestRepository.InsertAsync(newEntity);

            await _unitOfWorkManager.Current.SaveChangesAsync();

            return ObjectMapper.Map<PathologyTest, PathologyTestDto>(pathologyTest);
        }

        public async Task<PathologyTestDto> UpdateAsync(PathologyTestInputDto input)
        {
            var updateItem = ObjectMapper.Map<PathologyTestInputDto, PathologyTest>(input);

            var item = await _pathologyTestRepository.UpdateAsync(updateItem);

            await _unitOfWorkManager.Current.SaveChangesAsync();

            return ObjectMapper.Map<PathologyTest, PathologyTestDto>(item);
        }


        public async Task<PathologyTestDto> GetAsync(int id)
        {
            var item = await _pathologyTestRepository.GetAsync(x => x.Id == id);

            return ObjectMapper.Map<PathologyTest, PathologyTestDto>(item);
        }
        public async Task<List<PathologyTestDto>> GetListAsync()
        {
            List<PathologyTestDto>? result = null;

            var allPathologyTestDetails = await _pathologyTestRepository.WithDetailsAsync(p => p.PathologyCategory);
            if (!allPathologyTestDetails.Any())
            {
                return result;
            }
            result = new List<PathologyTestDto>();
            foreach (var item in allPathologyTestDetails)
            {

                result.Add(new PathologyTestDto()
                {
                    Id = item.Id,
                    PathologyCategoryId = item.PathologyCategoryId,
                    PathologyCategoryName = item.PathologyCategoryId > 0 ? item.PathologyCategory.PathologyCategoryName : "",
                    PathologyTestDescription = item.PathologyTestDescription,
                    PathologyTestName = item.PathologyTestName,

                });
            }
            var resList = result.OrderByDescending(d => d.Id).ToList();
            return resList;
            //var pathologyTests = await _pathologyTestRepository.GetListAsync();
            //return ObjectMapper.Map<List<PathologyTest>, List<PathologyTestDto>>(pathologyTests).OrderByDescending(a=>a.Id).ToList();


            //result = result.OrderByDescending(a => a.AppointmentDate).ToList();
            //var list = result.OrderBy(item => item.AppointmentSerial)
            //    .GroupBy(item => item.AppointmentDate)
            //    .OrderBy(g => g.Key).Select(g => new { g }).ToList();


            //return result;
        }
    }
}
