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
    public class DoctorSpecializationService : SoowGoodWebAppService, IDoctorSpecializationService
    {
        private readonly IRepository<DoctorSpecialization> _doctorSpecializationRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        public DoctorSpecializationService(IRepository<DoctorSpecialization> doctorSpecializationRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _doctorSpecializationRepository = doctorSpecializationRepository;
            _unitOfWorkManager = unitOfWorkManager;
        }
        public async Task<DoctorSpecializationDto> CreateAsync(DoctorSpecializationInputDto input)
        {
            var newEntity = ObjectMapper.Map<DoctorSpecializationInputDto, DoctorSpecialization>(input);

            var doctorSpecialization = await _doctorSpecializationRepository.InsertAsync(newEntity);

            await _unitOfWorkManager.Current.SaveChangesAsync();

            return ObjectMapper.Map<DoctorSpecialization, DoctorSpecializationDto>(doctorSpecialization);
        }
        public async Task<DoctorSpecializationDto> GetAsync(int id)
        {
            var item = await _doctorSpecializationRepository.GetAsync(x => x.Id == id);

            return ObjectMapper.Map<DoctorSpecialization, DoctorSpecializationDto>(item);
        }
        public async Task<DoctorSpecializationDto> GetBySpecialityIdAsync(int specialityId)
        {
            var item = await _doctorSpecializationRepository.GetAsync(x => x.SpecialityId == specialityId);

            return ObjectMapper.Map<DoctorSpecialization, DoctorSpecializationDto>(item);
        }
        public async Task<List<DoctorSpecializationDto>> GetListAsync()
        {
            var specialization = await _doctorSpecializationRepository.GetListAsync();
            return ObjectMapper.Map<List<DoctorSpecialization>, List<DoctorSpecializationDto>>(specialization);
        }
        public async Task<List<DoctorSpecializationDto>> GetDoctorSpecializationListBySpecialityIdAsync(int specialityId)
        {
            var specialization = await _doctorSpecializationRepository.GetListAsync(x => x.SpecialityId == specialityId);
            return ObjectMapper.Map<List<DoctorSpecialization>, List<DoctorSpecializationDto>>(specialization);
        }
        public async Task<List<DoctorSpecializationDto>> GetDoctorSpecializationListByDoctorIdAsync(int doctorId)
        {
            var docSpecialization = await _doctorSpecializationRepository.WithDetailsAsync(x => x.DoctorProfile, t=>t.Speciality, s=>s.Specialization);
            var specialization = docSpecialization.Where(x => x.DoctorProfileId == doctorId);
            return ObjectMapper.Map<List<DoctorSpecialization>, List<DoctorSpecializationDto>>(specialization.ToList());
        }
        public async Task<List<DoctorSpecializationDto>> GetDoctorSpecializationListByDoctorIdSpecialityIdAsync(int doctorId, int specialityId)
        {
            var docSpecialization = await _doctorSpecializationRepository.WithDetailsAsync(x => x.DoctorProfile, t => t.Speciality, s => s.Specialization);
            var specialization = docSpecialization.Where(x => x.DoctorProfileId == doctorId && x.SpecialityId == specialityId);
            //var specialization = await _doctorSpecializationRepository.GetListAsync(x => x.DoctorProfileId == doctorId && x.SpecialityId == specialityId);
            return ObjectMapper.Map<List<DoctorSpecialization>, List<DoctorSpecializationDto>>(specialization.ToList());
        }
        public async Task<List<DoctorSpecializationDto>?> GetListByDoctorIdSpIdAsync(int doctorId, int specialityId)
        {
            List<DoctorSpecializationDto> list = null;
            var items = await _doctorSpecializationRepository.WithDetailsAsync(d => d.Specialization, s => s.Speciality);
            items = items.Where(i => i.DoctorProfileId == doctorId && i.SpecialityId == specialityId);
            if (items.Any())
            {
                list = new List<DoctorSpecializationDto>();
                foreach (var item in items)
                {
                    list.Add(new DoctorSpecializationDto()
                    {
                        Id = item.Id,
                        SpecializationId = item.SpecializationId,
                        SpecialityId = item.SpecialityId,
                        DoctorProfileId = item.DoctorProfileId,
                        SpecialityName = item.Speciality?.SpecialityName,
                        SpecializationName = item.Specialization?.SpecializationName,
                        DocumentName=item.DocumentName,
                    });
                }
            }

            return list != null ? list : null;
        }
        public async Task<DoctorSpecializationDto> UpdateAsync(DoctorSpecializationInputDto input)
        {
            var updateItem = ObjectMapper.Map<DoctorSpecializationInputDto, DoctorSpecialization>(input);

            var item = await _doctorSpecializationRepository.UpdateAsync(updateItem);

            return ObjectMapper.Map<DoctorSpecialization, DoctorSpecializationDto>(item);
        }

        public async Task DeleteAsync(long id)
        {
            await _doctorSpecializationRepository.DeleteAsync(d => d.Id == id);
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
