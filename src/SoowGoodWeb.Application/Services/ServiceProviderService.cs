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
    public class ServiceProviderService : SoowGoodWebAppService, IServiceProviderService
    {
        private readonly IRepository<ServiceProvider> _serviceProviderRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        private readonly IRepository<DoctorProfile> _doctorProfileRepository;

        public ServiceProviderService(IRepository<ServiceProvider> serviceProviderRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _serviceProviderRepository = serviceProviderRepository;

            _unitOfWorkManager = unitOfWorkManager;
        }
        public async Task<ServiceProviderDto> CreateAsync(ServiceProviderInputDto input)
        {
            var newEntity = ObjectMapper.Map<ServiceProviderInputDto, ServiceProvider>(input);

            var serviceProvider = await _serviceProviderRepository.InsertAsync(newEntity);

            await _unitOfWorkManager.Current.SaveChangesAsync();

            return ObjectMapper.Map<ServiceProvider, ServiceProviderDto>(serviceProvider);
        }

        public async Task<ServiceProviderDto> UpdateAsync(ServiceProviderInputDto input)
        {
            var updateItem = ObjectMapper.Map<ServiceProviderInputDto, ServiceProvider>(input);

            var item = await _serviceProviderRepository.UpdateAsync(updateItem);

            await _unitOfWorkManager.Current.SaveChangesAsync();

            return ObjectMapper.Map<ServiceProvider, ServiceProviderDto>(item);
        }


        public async Task<ServiceProviderDto> GetAsync(int id)
        {
            var item = await _serviceProviderRepository.GetAsync(x => x.Id == id);

            return ObjectMapper.Map<ServiceProvider, ServiceProviderDto>(item);
        }
        public async Task<List<ServiceProviderDto>> GetListAsync()
        {
            List<ServiceProviderDto>? result = null;

            var allServiceProviderDetails = await _serviceProviderRepository.WithDetailsAsync(p => p.PlatformFacility);
            if (!allServiceProviderDetails.Any())
            {
                return result;
            }
            result = new List<ServiceProviderDto>();
            foreach (var item in allServiceProviderDetails)
            {

                result.Add(new ServiceProviderDto()
                {

                    Id = item.Id,
                    PlatformFacilityId = item.PlatformFacilityId,
                    PlatformFacilityName = item.PlatformFacilityId > 0 ? item.PlatformFacility.ServiceName : "",
                    ProviderOrganizationName = item.ProviderOrganizationName,
                    OrganizationCode = item.OrganizationCode,
                    OrganizationAvailability = item.OrganizationAvailability,
                    OrganizationPhoneNumber = item.OrganizationPhoneNumber,
                    ContactPerson = item.ContactPerson,
                    ContactPersonEmail = item.ContactPersonEmail,
                    ContactPersonMobileNo = item.ContactPersonMobileNo,
                    Branch = item.Branch,
                    Address = item.Address,
                    IsActive = item.IsActive,

                });
            }
            var resList = result.OrderByDescending(d => d.Id).ToList();
            return resList;
            //var serviceProviders = await _serviceProviderRepository.GetListAsync();
            //return ObjectMapper.Map<List<ServiceProvider>, List<ServiceProviderDto>>(serviceProviders).OrderByDescending(a=>a.Id).ToList();


            //result = result.OrderByDescending(a => a.AppointmentDate).ToList();
            //var list = result.OrderBy(item => item.AppointmentSerial)
            //    .GroupBy(item => item.AppointmentDate)
            //    .OrderBy(g => g.Key).Select(g => new { g }).ToList();


            //return result;
        }


        public async Task<List<ServiceProviderDto>> GetListByFacilityIdAsync(long facilityId)
        {
            var serviceProviders = await _serviceProviderRepository.WithDetailsAsync(f => f.PlatformFacility);
            var serviceProviderList = serviceProviders.Where(p => p.PlatformFacilityId == facilityId).ToList();
            return ObjectMapper.Map<List<ServiceProvider>, List<ServiceProviderDto>>(serviceProviderList).OrderByDescending(a => a.Id).ToList();

        }

        public async Task<List<string>> GetListBySlugAsync(string slug)
        {
            var serviceProviders = await _serviceProviderRepository.WithDetailsAsync(f => f.PlatformFacility);
            var serviceProviderList = serviceProviders.Where(p => p.PlatformFacility.Slug == slug).ToList();
            var distinctProviders = serviceProviderList.Select(s => s.ProviderOrganizationName).Distinct().ToList();

            //var providers = (from sp in serviceProviderList join dp in distinctProviders on sp.ProviderOrganizationName equals dp select sp).ToList();

            return distinctProviders; //ObjectMapper.Map<List<ServiceProvider>, List<ServiceProviderDto>>(providers).OrderByDescending(a => a.Id).ToList();

        }

        public async Task<List<ServiceProviderDto>> GetBranchListByProviderNameAsync(string providerName)
        {
            var serviceProviders = await _serviceProviderRepository.WithDetailsAsync(f => f.PlatformFacility);
            var serviceProviderList = serviceProviders.Where(p => p.ProviderOrganizationName == providerName).ToList();
            return ObjectMapper.Map<List<ServiceProvider>, List<ServiceProviderDto>>(serviceProviderList).OrderByDescending(a => a.Id).ToList();

        }

        public async Task<List<ServiceProviderDto>> GetServiceProviderListFilterByAdminAsync(DataFilterModel? providerFilterModel, FilterModel filterModel)
        {
            List<ServiceProviderDto> result = null;
            try
            {
                var profileWithDetails = await _serviceProviderRepository.WithDetailsAsync(p => p.PlatformFacility);

                var profiles = profileWithDetails.Where(p => !string.IsNullOrEmpty(p.ContactPerson)).ToList();
                //var schedules = await _patientProfileRepository.WithDetailsAsync();
                //var scheduleCons = schedules.Where(s=>(s.ConsultancyType == consultType)
                if (!profileWithDetails.Any())
                {
                    return result;
                }
                result = new List<ServiceProviderDto>();
                if (providerFilterModel != null && !string.IsNullOrEmpty(providerFilterModel.name))
                {
                    //profiles = profiles.Where(p => p.PatientName.ToLower().Contains(patientFilterModel.name.ToLower().Trim())).ToList();
                    profiles = profiles.Where(p => p.ContactPerson.ToLower().Contains(providerFilterModel.name.ToLower().Trim())).ToList();
                }
                foreach (var item in profiles)
                {

                    result.Add(new ServiceProviderDto()
                    {
                        Id = item.Id,
                        PlatformFacilityId = item.PlatformFacilityId,
                        PlatformFacilityName = item.PlatformFacilityId > 0 ? item.PlatformFacility.ServiceName : "",
                        ProviderOrganizationName = item.ProviderOrganizationName,
                        OrganizationCode = item.OrganizationCode,
                        OrganizationAvailability = item.OrganizationAvailability,
                        OrganizationPhoneNumber = item.OrganizationPhoneNumber,
                        ContactPerson = item.ContactPerson,
                        ContactPersonEmail = item.ContactPersonEmail,
                        ContactPersonMobileNo = item.ContactPersonMobileNo,
                        Branch = item.Branch,
                        Address = item.Address,
                        IsActive = item.IsActive,

                    });
                }


                //result = result.Skip(filterModel.Offset)
                //                   .Take(filterModel.Limit).ToList();
            }
            catch
            {
                return null;
            }

            return result;
        }

    }
}
