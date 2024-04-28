using SoowGoodWeb.DtoModels;
using SoowGoodWeb.InputDto;
using SoowGoodWeb.Interfaces;
using SoowGoodWeb.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Uow;

namespace SoowGoodWeb.Services
{
    public class DoctorChamberService : SoowGoodWebAppService, IDoctorChamberService
    {
        private readonly IRepository<DoctorChamber> _doctorChamberRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        public DoctorChamberService(IRepository<DoctorChamber> doctorChamberRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _doctorChamberRepository = doctorChamberRepository;

            _unitOfWorkManager = unitOfWorkManager;
        }
        public async Task<DoctorChamberDto> CreateAsync(DoctorChamberInputDto input)
        {
            var newEntity = ObjectMapper.Map<DoctorChamberInputDto, DoctorChamber>(input);

            var doctorChamber = await _doctorChamberRepository.InsertAsync(newEntity);

            //await _unitOfWorkManager.Current.SaveChangesAsync();

            return ObjectMapper.Map<DoctorChamber, DoctorChamberDto>(doctorChamber);
        }

        public async Task<DoctorChamberDto> GetAsync(int id)
        {
            var item = await _doctorChamberRepository.GetAsync(x => x.Id == id);

            return ObjectMapper.Map<DoctorChamber, DoctorChamberDto>(item);
        }
        public async Task<List<DoctorChamberDto>> GetListAsync()
        {
            var degrees = await _doctorChamberRepository.GetListAsync();
            return ObjectMapper.Map<List<DoctorChamber>, List<DoctorChamberDto>>(degrees);
        }
        public async Task<List<DoctorChamberDto>> GetDoctorChamberListByDoctorIdAsync(int doctorId)
        {
            var doctDegrees = await _doctorChamberRepository.GetListAsync(dd => dd.DoctorProfileId == doctorId);
            return ObjectMapper.Map<List<DoctorChamber>, List<DoctorChamberDto>>(doctDegrees);
        }
        public async Task<DoctorChamberDto> UpdateAsync(DoctorChamberInputDto input)
        {
            var updateItem = ObjectMapper.Map<DoctorChamberInputDto, DoctorChamber>(input);

            var item = await _doctorChamberRepository.UpdateAsync(updateItem);

            return ObjectMapper.Map<DoctorChamber, DoctorChamberDto>(item);
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
