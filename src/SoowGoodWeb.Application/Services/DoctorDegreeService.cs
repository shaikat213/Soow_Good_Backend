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
    public class DoctorDegreeService : SoowGoodWebAppService, IDoctorDegreeService
    {
        private readonly IRepository<DoctorDegree> _doctorDegreeRepository;
        private readonly IRepository<Degree> _degreeRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        public DoctorDegreeService(IRepository<DoctorDegree> doctorDegreeRepository, IRepository<Degree> degreeRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _doctorDegreeRepository = doctorDegreeRepository;
            _degreeRepository = degreeRepository;
            _unitOfWorkManager = unitOfWorkManager;
        }
        public async Task<DoctorDegreeDto> CreateAsync(DoctorDegreeInputDto input)
        {
            var result = new DoctorDegreeDto();
            var degree = await _degreeRepository.GetAsync(d => d.Id == input.DegreeId);
            var newEntity = ObjectMapper.Map<DoctorDegreeInputDto, DoctorDegree>(input);

            var doctorDegree = await _doctorDegreeRepository.InsertAsync(newEntity);

            await _unitOfWorkManager.Current.SaveChangesAsync();
            result = ObjectMapper.Map<DoctorDegree, DoctorDegreeDto>(doctorDegree);
            result.DegreeName = degree.DegreeName;
            return result;//ObjectMapper.Map<DoctorDegree, DoctorDegreeDto>(result);
        }

        public async Task<DoctorDegreeDto> GetAsync(int id)
        {
            var item = await _doctorDegreeRepository.GetAsync(x => x.Id == id);

            return ObjectMapper.Map<DoctorDegree, DoctorDegreeDto>(item);
        }
        public async Task<List<DoctorDegreeDto>> GetListAsync()
        {
            var degrees = await _doctorDegreeRepository.GetListAsync();
            return ObjectMapper.Map<List<DoctorDegree>, List<DoctorDegreeDto>>(degrees);
        }
        public async Task<List<DoctorDegreeDto>> GetDoctorDegreeListByDoctorIdAsync(int doctorId)
        {
            var degrees = await _doctorDegreeRepository.WithDetailsAsync(d => d.Degree);
            var doctDegrees = degrees.Where(dd => dd.DoctorProfileId == doctorId).ToList();
            return ObjectMapper.Map<List<DoctorDegree>, List<DoctorDegreeDto>>(doctDegrees);
        }
        public async Task<List<DoctorDegreeDto>> GetListByDoctorIdAsync(int doctorId)
        {
            List<DoctorDegreeDto> list = null;
            var items = await _doctorDegreeRepository.WithDetailsAsync(d => d.Degree);
            items = items.Where(i => i.DoctorProfileId == doctorId);
            if (items.Any())
            {
                list = new List<DoctorDegreeDto>();
                foreach (var item in items)
                {
                    list.Add(new DoctorDegreeDto()
                    {
                        Id = item.Id,
                        DegreeName = item.Degree?.DegreeName,
                        PassingYear = item.PassingYear,
                        Duration = item.Duration,
                        InstituteName = item.InstituteName,
                        InstituteCity = item.InstituteCity,
                        InstituteCountry = item.InstituteCountry,
                    });
                }
            }

            return list;
        }
        public async Task<DoctorDegreeDto> UpdateAsync(DoctorDegreeInputDto input)
        {
            var updateItem = ObjectMapper.Map<DoctorDegreeInputDto, DoctorDegree>(input);

            var item = await _doctorDegreeRepository.UpdateAsync(updateItem);

            return ObjectMapper.Map<DoctorDegree, DoctorDegreeDto>(item);
        }

        public async Task DeleteAsync(long id)
        {
            await _doctorDegreeRepository.DeleteAsync(d => d.Id == id);
        }

        //public async Task<List<DoctorProfileDto>> GetListAsync()
        //{
        //    List<DoctorProfileDto> list = null;
        //    var items = await _doctorProfileRepository.WithDetailsAsync(p => p.District);
        //    if (items.Any())
        //    {
        //        list = new List<DoctorProfileDto>();
        //        foreach (var item in items)
        //        {
        //            list.Add(new DoctorProfileDto()
        //            {
        //                Id = item.Id,
        //                Name = item.Name,
        //                Description = item.Description,
        //                DistrictId = item.DistrictId,
        //                DistrictName = item.District?.Name,
        //                CivilSubDivisionId = item.CivilSubDivisionId,
        //                EmSubDivisionId = item.EmSubDivisionId,
        //            });
        //        }
        //    }

        //    return list;
        //}
        //public async Task<List<QuarterDto>> GetListByDistrictAsync(int id)
        //{
        //    List<QuarterDto> list = null;
        //    var items = await repository.WithDetailsAsync(p => p.District);
        //    items = items.Where(i => i.DistrictId == id);
        //    if (items.Any())
        //    {
        //        list = new List<QuarterDto>();
        //        foreach (var item in items)
        //        {
        //            list.Add(new QuarterDto()
        //            {
        //                Id = item.Id,
        //                Name = item.Name,
        //                Description = item.Description,
        //                DistrictId = item.DistrictId,
        //                DistrictName = item.District?.Name,
        //                CivilSubDivisionId = item.CivilSubDivisionId,
        //                EmSubDivisionId = item.EmSubDivisionId,
        //            });
        //        }
        //    }

        //    return list;
        //}

        //public async Task<int> GetCountAsync()
        //{
        //    return (await quarterRepository.GetListAsync()).Count;
        //}
        //public async Task<List<QuarterDto>> GetSortedListAsync(FilterModel filterModel)
        //{
        //    var quarters = await quarterRepository.WithDetailsAsync();
        //    quarters = quarters.Skip(filterModel.Offset)
        //                    .Take(filterModel.Limit);
        //    return ObjectMapper.Map<List<Quarter>, List<QuarterDto>>(quarters.ToList());
        //}
        ////public async Task<int> GetCountBySDIdAsync(Guid? civilSDId, Guid? emSDId)
        //public async Task<int> GetCountBySDIdAsync(Guid? sdId)
        //{
        //    var quarters = await quarterRepository.WithDetailsAsync();
        //    //if (civilSDId != null && emSDId != null)
        //    //{
        //    //    quarters = quarters.Where(q => q.CivilSubDivisionId == civilSDId && q.EmSubDivisionId == emSDId);
        //    //}
        //    if (sdId != null)
        //    {
        //        quarters = quarters.Where(q => q.CivilSubDivisionId == sdId || q.EmSubDivisionId == sdId);
        //    }
        //    //else if (emSDId != null)
        //    //{
        //    //    quarters = quarters.Where(q => q.EmSubDivisionId == emSDId);
        //    //}
        //    return quarters.Count();
        //}
        ////public async Task<List<QuarterDto>> GetSortedListBySDIdAsync(Guid? civilSDId, Guid? emSDId, FilterModel filterModel)
        //public async Task<List<QuarterDto>> GetSortedListBySDIdAsync(Guid? sdId, FilterModel filterModel)
        //{
        //    var quarters = await quarterRepository.WithDetailsAsync();
        //    //if (civilSDId != null && emSDId != null)
        //    //{
        //    //    quarters = quarters.Where(q => q.CivilSubDivisionId == civilSDId && q.EmSubDivisionId == emSDId);
        //    //}
        //    //else if (civilSDId != null)
        //    //{
        //    if (sdId != null)
        //        quarters = quarters.Where(q => q.CivilSubDivisionId == sdId || q.EmSubDivisionId == sdId);
        //    //}
        //    //else if (emSDId != null)
        //    //{
        //    //    quarters = quarters.Where(q => q.EmSubDivisionId == emSDId);
        //    //}
        //    quarters = quarters.Skip(filterModel.Offset)
        //                    .Take(filterModel.Limit);
        //    return ObjectMapper.Map<List<Quarter>, List<QuarterDto>>(quarters.ToList());
        //}
        //public async Task<List<QuarterDto>> GetListBySDIdAsync(Guid? sdId)
        //{
        //    var quarters = await quarterRepository.WithDetailsAsync();
        //    if (sdId != null)
        //    {
        //        quarters = quarters.Where(q => q.CivilSubDivisionId == sdId || q.EmSubDivisionId == sdId);
        //    }
        //    return ObjectMapper.Map<List<Quarter>, List<QuarterDto>>(quarters.ToList());
        //}
    }
}
