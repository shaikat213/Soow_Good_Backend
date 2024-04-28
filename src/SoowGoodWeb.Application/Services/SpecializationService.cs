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
    public class SpecializationService : SoowGoodWebAppService, ISpecializationService
    {
        private readonly IRepository<Specialization> _specializationRepository;
        private readonly IRepository<DoctorSpecialization> _doctorSpecializationRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        public SpecializationService(IRepository<Specialization> specializationRepository, IRepository<DoctorSpecialization> doctorSpecializationRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _specializationRepository = specializationRepository;
            _doctorSpecializationRepository = doctorSpecializationRepository;
            _unitOfWorkManager = unitOfWorkManager;
        }
        //public async Task<DoctorProfileDto> CreateAsync(DoctorProfileInputDto input)
        //{
        //    var newEntity = ObjectMapper.Map<DoctorProfileInputDto, DoctorProfile>(input);

        //    var doctorProfile = await _doctorProfileRepository.InsertAsync(newEntity);

        //    //await _unitOfWorkManager.Current.SaveChangesAsync();

        //    return ObjectMapper.Map<DoctorProfile, DoctorProfileDto>(doctorProfile);
        //}

        public async Task<SpecializationDto> GetAsync(int id)
        {
            var item = await _specializationRepository.GetAsync(x => x.Id == id);

            return ObjectMapper.Map<Specialization, SpecializationDto>(item);
        }
        public async Task<List<SpecializationDto>> GetListAsync()
        {
            var allsPecialization = await _specializationRepository.WithDetailsAsync(s => s.Speciality);
            var specialization = allsPecialization.ToList();
            return ObjectMapper.Map<List<Specialization>, List<SpecializationDto>>(specialization);
        }
        public async Task<List<SpecializationDto>> GetListFilteringAsync()
        {
            var allsPecialization = await _specializationRepository.WithDetailsAsync(s => s.Speciality);
            var docSp = await _doctorSpecializationRepository.WithDetailsAsync(sp => sp.Specialization);
            var specialization = (from alsp in allsPecialization join dsp in docSp on alsp.Id equals dsp.SpecializationId select alsp).Distinct().ToList() ;
            return ObjectMapper.Map<List<Specialization>, List<SpecializationDto>>(specialization);
        }
        public async Task<List<SpecializationDto>> GetListBySpecialtyIdAsync(long specialityId)
        {
            var specializations = await _specializationRepository.WithDetailsAsync(s=>s.Speciality);
            var specialization = specializations.Where(s=>s.SpecialityId == specialityId ).ToList();
            return ObjectMapper.Map<List<Specialization>, List<SpecializationDto>>(specialization);
        }
        public async Task<SpecializationDto> GetBySpecialityIdAsync(int specialityId)
        {
            var allsPecialization = await _specializationRepository.WithDetailsAsync(s => s.Speciality);
            var item = allsPecialization.FirstOrDefault(x => x.SpecialityId == specialityId);

            return ObjectMapper.Map<Specialization, SpecializationDto>(item);
        }

        public async Task<SpecializationDto> CreateAsync(SpecializationInputDto input)
        {
            var newEntity = ObjectMapper.Map<SpecializationInputDto, Specialization>(input);

            var specialization = await _specializationRepository.InsertAsync(newEntity);

            await _unitOfWorkManager.Current.SaveChangesAsync();

            return ObjectMapper.Map<Specialization, SpecializationDto>(specialization);
        }

        public async Task<SpecializationDto> UpdateAsync(SpecializationInputDto input)
        {
            var updateItem = ObjectMapper.Map<SpecializationInputDto, Specialization>(input);

            var item = await _specializationRepository.UpdateAsync(updateItem);

            await _unitOfWorkManager.Current.SaveChangesAsync();

            return ObjectMapper.Map<Specialization, SpecializationDto>(item);
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
        //public async Task<DoctorProfileDto> UpdateAsync(DoctorProfileInputDto input)
        //{
        //    var updateItem = ObjectMapper.Map<DoctorProfileInputDto, DoctorProfile>(input);

        //    var item = await _doctorProfileRepository.UpdateAsync(updateItem);

        //    return ObjectMapper.Map<DoctorProfile, DoctorProfileDto>(item);
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
