using SoowGoodWeb.DtoModels;
using SoowGoodWeb.InputDto;
using SoowGoodWeb.Interfaces;
using SoowGoodWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Account;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;
using Volo.Abp.Uow;

namespace SoowGoodWeb.Services
{
    public class AgentProfileService : SoowGoodWebAppService, IAgentProfileService
    {
        private readonly IRepository<AgentProfile> _agentProfileRepository;
        //private readonly IRepository<AgentDegree> _agentDegreeRepository;
        //private readonly IRepository<AgentSpecialization> _agentSpecializationRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        public AgentProfileService(IRepository<AgentProfile> agentProfileRepository
                                    , IUnitOfWorkManager unitOfWorkManager)
        {
            _agentProfileRepository = agentProfileRepository;
            _unitOfWorkManager = unitOfWorkManager;
        }
        public async Task<AgentProfileDto> CreateAsync(AgentProfileInputDto input)
        {
            var totalAgentMaters = await _agentProfileRepository.GetListAsync();
            var count = totalAgentMaters.Count();
            input.AgentCode = "SGAG00" + (count + 1);
            var newEntity = ObjectMapper.Map<AgentProfileInputDto, AgentProfile>(input);

            var agentProfile = await _agentProfileRepository.InsertAsync(newEntity);

            //await _unitOfWorkManager.Current.SaveChangesAsync();

            return ObjectMapper.Map<AgentProfile, AgentProfileDto>(agentProfile);
        }

        public async Task<AgentProfileDto> GetAsync(int id)
        {
            var item = await _agentProfileRepository.GetAsync(x => x.Id == id);

            return ObjectMapper.Map<AgentProfile, AgentProfileDto>(item);

            //var item = await _agentProfileRepository.WithDetailsAsync();
            //var profile = item.FirstOrDefault(item => item.Id == id);
            //var result = profile != null ? ObjectMapper.Map<AgentProfile, AgentProfileDto>(profile) : null;

            //return result;
        } 

        public async Task<AgentProfileDto> GetByUserNameAsync(string userName)
        {
            var item = await _agentProfileRepository.GetAsync(x => x.MobileNo == userName);

            return ObjectMapper.Map<AgentProfile, AgentProfileDto>(item);
        }
        public async Task<List<AgentProfileDto>> GetListAsync()
        {
            var result = new List<AgentProfileDto>();
            try
            {
                var profiles = await _agentProfileRepository.WithDetailsAsync(m => m.AgentMaster, s => s.AgentSupervisor);
                var item = profiles.ToList();
                if (item.Any())
                {
                    foreach (var profile in item)
                    {
                        result.Add(new AgentProfileDto()
                        {
                            Id = profile.Id,
                            AgentCode = profile.AgentCode,
                            FullName = profile.FullName,
                            MobileNo = profile.MobileNo,
                            Email = profile.Email,
                            OrganizationName = profile.OrganizationName,
                            City = profile.City,
                            Address = profile.Address,
                            AgentMasterId = profile.AgentMasterId,
                            AgentSupervisorId= profile.AgentSupervisorId,
                            AgentDocNumber = profile.AgentDocNumber,
                            AgentDocExpireDate = profile.AgentDocExpireDate,
                            AgentMasterName = profile?.AgentMaster?.ContactPerson,
                            AgentSupervisorName = profile?.AgentSupervisor?.SupervisorName,
                            ZipCode = profile?.ZipCode,
                            Country = profile?.Country,
                            IsActive = profile?.IsActive,

                        });
                    }
                }
            }
            catch (Exception e) { }

            return result.OrderByDescending(x=>x.Id).ToList();//ObjectMapper.Map<List<AgentProfile>, List<AgentProfileDto>>(item);
        }
        public async Task<List<AgentProfileDto>> GetListBySupervisorIdAsync( long supervisorId)
        {
            var result = new List<AgentProfileDto>();
            try
            {
                var profiles = await _agentProfileRepository.WithDetailsAsync(m => m.AgentMaster, s => s.AgentSupervisor);
                var agentProfile = profiles.Where(a => a.AgentSupervisorId == supervisorId).ToList();
                if (agentProfile.Any())
                {
                    foreach (var profile in agentProfile)
                    {
                        result.Add(new AgentProfileDto()
                        {
                            Id = profile.Id,
                            AgentCode = profile.AgentCode,
                            FullName = profile.FullName,
                            MobileNo = profile.MobileNo,
                            Email = profile.Email,
                            OrganizationName = profile.OrganizationName,
                            City = profile.City,
                            Address = profile.Address,
                            AgentMasterId = profile.AgentMasterId,
                            AgentSupervisorId = profile.AgentSupervisorId,
                            AgentDocNumber = profile.AgentDocNumber,
                            AgentDocExpireDate = profile.AgentDocExpireDate,
                            AgentMasterName = profile?.AgentMaster?.ContactPerson,
                            AgentSupervisorName = profile?.AgentSupervisor?.SupervisorName,
                            ZipCode = profile?.ZipCode,
                            Country = profile?.Country,
                            IsActive = profile?.IsActive,

                        });
                    }
                }
            }
            catch (Exception e) { }

            return result.OrderByDescending(x => x.Id).ToList();//ObjectMapper.Map<List<AgentProfile>, List<AgentProfileDto>>(item);
        }

        public async Task<List<AgentProfileDto>> GetListByMasterIdAsync( long masterId)
        {
            var result = new List<AgentProfileDto>();
            try
            {
                var profiles = await _agentProfileRepository.WithDetailsAsync(m => m.AgentMaster, s => s.AgentSupervisor);
                var agentProfile=profiles.Where(a=>a.AgentMasterId == masterId).ToList();
                
                if (agentProfile.Any())
                {
                    foreach (var profile in agentProfile)
                    {
                        result.Add(new AgentProfileDto()
                        {
                            Id = profile.Id,
                            AgentCode = profile.AgentCode,
                            FullName = profile.FullName,
                            MobileNo = profile.MobileNo,
                            Email = profile.Email,
                            OrganizationName = profile.OrganizationName,
                            City = profile.City,
                            Address = profile.Address,
                            AgentMasterId = profile.AgentMasterId,
                            AgentSupervisorId = profile.AgentSupervisorId,
                            AgentDocNumber = profile.AgentDocNumber,
                            AgentDocExpireDate = profile.AgentDocExpireDate,
                            AgentMasterName = profile?.AgentMaster?.ContactPerson,
                            AgentSupervisorName = profile?.AgentSupervisor?.SupervisorName,
                            ZipCode = profile?.ZipCode,
                            Country = profile?.Country,
                            IsActive = profile?.IsActive,

                        });
                    }
                }
            }
            catch (Exception e) { }

            return result.OrderByDescending(x => x.Id).ToList();//ObjectMapper.Map<List<AgentProfile>, List<AgentProfileDto>>(item);
        }
        public async Task<AgentProfileDto> GetByUserIdAsync(Guid userId)
        {
            var item = await _agentProfileRepository.GetAsync(x => x.UserId == userId);
            return ObjectMapper.Map<AgentProfile, AgentProfileDto>(item);
        }

        public async Task<AgentProfileDto> UpdateAsync(AgentProfileInputDto input)
        {
            var result = new AgentProfileDto();
            try
            {
                var itemAgent = await _agentProfileRepository.GetAsync(d => d.Id == input.Id);
                itemAgent.FullName = !string.IsNullOrEmpty(input.FullName) ? input.FullName : itemAgent.FullName;
                itemAgent.AgentCode = !string.IsNullOrEmpty(input.AgentCode) ? input.AgentCode : itemAgent.AgentCode;
                itemAgent.OrganizationName = !string.IsNullOrEmpty(input.OrganizationName) ? input.OrganizationName : itemAgent.OrganizationName;
                itemAgent.Email = !string.IsNullOrEmpty(input.Email) ? input.Email : itemAgent.Email;
                itemAgent.MobileNo = itemAgent.MobileNo;

                itemAgent.Address = !string.IsNullOrEmpty(input.Address) ? input.Address : itemAgent.Address;
                itemAgent.City = !string.IsNullOrEmpty(input.City) ? input.City : itemAgent.City;
                itemAgent.Country = !string.IsNullOrEmpty(input.Country) ? input.Country : itemAgent.Country;
                itemAgent.ZipCode = !string.IsNullOrEmpty(input.ZipCode) ? input.ZipCode : itemAgent.ZipCode;
                itemAgent.AgentMasterId = input.AgentMasterId > 0 ? input.AgentMasterId : itemAgent.AgentMasterId;
                itemAgent.AgentSupervisorId = input.AgentSupervisorId > 0 ? input.AgentSupervisorId : itemAgent.AgentSupervisorId;
                itemAgent.IsActive = input.IsActive; //itemAgent.IsActive == false ? input.IsActive : itemAgent.IsActive;
                itemAgent.UserId = itemAgent.UserId;
                itemAgent.profileStep = itemAgent.profileStep;
                itemAgent.createFrom = !string.IsNullOrEmpty(input.createFrom) ? input.createFrom : itemAgent.Address;
                itemAgent.AgentDocNumber = !string.IsNullOrEmpty(input.AgentDocNumber) ? input.AgentDocNumber : itemAgent.AgentDocNumber;
                itemAgent.AgentDocExpireDate = input.AgentDocExpireDate != null ? input.AgentDocExpireDate : itemAgent.AgentDocExpireDate;

                var item = await _agentProfileRepository.UpdateAsync(itemAgent);
                await _unitOfWorkManager.Current.SaveChangesAsync();
                result = ObjectMapper.Map<AgentProfile, AgentProfileDto>(item);
            }
            catch (Exception ex)
            {
                return null;
            }
            return result;

        }

        public async Task<AgentProfileDto> GetlByUserNameAsync(string userName)
        {
            var item = await _agentProfileRepository.GetAsync(x => x.MobileNo == userName);

            return ObjectMapper.Map<AgentProfile, AgentProfileDto>(item);
        }

    }
}
