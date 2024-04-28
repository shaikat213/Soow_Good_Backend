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
    public class AgentMasterService : SoowGoodWebAppService, IAgentMasterService
    {
        private readonly IRepository<AgentMaster> _agentMasterRepository;
        //private readonly IRepository<AgentDegree> _agentDegreeRepository;
        //private readonly IRepository<AgentSpecialization> _agentSpecializationRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        public AgentMasterService(IRepository<AgentMaster> agentMasterRepository
                                    , IUnitOfWorkManager unitOfWorkManager)
        {
            _agentMasterRepository = agentMasterRepository;
            _unitOfWorkManager = unitOfWorkManager;
        }

        public async Task<AgentMasterDto> CreateAsync(AgentMasterInputDto input)
        {
            var totalAgentMaters = await _agentMasterRepository.GetListAsync();
            var count = totalAgentMaters.Count();
            input.AgentMasterCode = "SGAM00" + (count + 1);
            var newEntity = ObjectMapper.Map<AgentMasterInputDto, AgentMaster>(input);

            var agentMaster = await _agentMasterRepository.InsertAsync(newEntity);

            await _unitOfWorkManager.Current.SaveChangesAsync();

            return ObjectMapper.Map<AgentMaster, AgentMasterDto>(agentMaster);
        }

        public async Task<AgentMasterDto> GetAsync(int id)
        {
            var item = await _agentMasterRepository.WithDetailsAsync();

            var profile = item.FirstOrDefault(item => item.Id == id);

            var result = profile != null ? ObjectMapper.Map<AgentMaster, AgentMasterDto>(profile) : null;

            return result;
        }

        public async Task<AgentMasterDto> GetByUserNameAsync(string userName)
        {
            var agentMasters = await _agentMasterRepository.WithDetailsAsync();
            var item = agentMasters.Where(x => x.ContactPersongMobileNo == userName).FirstOrDefault();

            return ObjectMapper.Map<AgentMaster, AgentMasterDto>(item);
        }

        public async Task<List<AgentMasterDto>> GetListAsync()
        {
            var agentMasters = await _agentMasterRepository.GetListAsync();
            return ObjectMapper.Map<List<AgentMaster>, List<AgentMasterDto>>(agentMasters).OrderByDescending(d => d.Id).ToList();
        }

        public async Task<AgentMasterDto> UpdateAsync(AgentMasterInputDto input)
        {
            var updateItem = ObjectMapper.Map<AgentMasterInputDto, AgentMaster>(input);

            var item = await _agentMasterRepository.UpdateAsync(updateItem);
            await _unitOfWorkManager.Current.SaveChangesAsync();
            return ObjectMapper.Map<AgentMaster, AgentMasterDto>(item);
        }

        public async Task<List<AgentMasterDto>> GetAllAgentMasterListAsync()
        {
            //var agentSupervisors = await _agentSupervisorRepository.GetListAsync();
            var result = new List<AgentMasterDto>();
            var agentMasters = await _agentMasterRepository.GetListAsync();
            foreach (var item in agentMasters)
            {
                result.Add(new AgentMasterDto()
                {
                    Id = item.Id,
                    AgentMasterOrgName = item.AgentMasterOrgName,
                    DisplayName = item.AgentMasterCode + "-" + item.AgentMasterOrgName

                });
            }
            return result;
            //return ObjectMapper.Map<List<AgentSupervisor>, List<AgentSupervisorDto>>(agentSupervisors);
        }
        //public async Task<AgentProfileDto> CreateAsync(AgentProfileInputDto input)
        //{
        //    var newEntity = ObjectMapper.Map<AgentProfileInputDto, AgentProfile>(input);

        //    var agentProfile = await _agentProfileRepository.InsertAsync(newEntity);

        //    //await _unitOfWorkManager.Current.SaveChangesAsync();

        //    return ObjectMapper.Map<AgentProfile, AgentProfileDto>(agentProfile);
        //}

        //public async Task<AgentProfileDto> GetAsync(int id)
        //{
        //    var item = await _agentProfileRepository.GetAsync(x => x.Id == id);

        //    return ObjectMapper.Map<AgentProfile, AgentProfileDto>(item);

        //    //var item = await _agentProfileRepository.WithDetailsAsync();
        //    //var profile = item.FirstOrDefault(item => item.Id == id);
        //    //var result = profile != null ? ObjectMapper.Map<AgentProfile, AgentProfileDto>(profile) : null;

        //    //return result;
        //}

        //public async Task<AgentProfileDto> GetByUserNameAsync(string userName)
        //{
        //    var item = await _agentProfileRepository.GetAsync(x => x.MobileNo == userName);

        //    return ObjectMapper.Map<AgentProfile, AgentProfileDto>(item);
        //}

        //public async Task<AgentProfileDto> GetByUserIdAsync(Guid userId)
        //{
        //    var item = await _agentProfileRepository.GetAsync(x => x.UserId == userId);
        //    return ObjectMapper.Map<AgentProfile, AgentProfileDto>(item);
        //}

        //public async Task<AgentProfileDto> UpdateAsync(AgentProfileInputDto input)
        //{
        //    var updateItem = ObjectMapper.Map<AgentProfileInputDto, AgentProfile>(input);

        //    var item = await _agentProfileRepository.UpdateAsync(updateItem);
        //    await _unitOfWorkManager.Current.SaveChangesAsync();                        
        //    return ObjectMapper.Map<AgentProfile, AgentProfileDto>(item);
        //}

        //public async Task<AgentProfileDto> GetlByUserNameAsync(string userName)
        //{
        //    var item = await _agentProfileRepository.GetAsync(x => x.MobileNo == userName);

        //    return ObjectMapper.Map<AgentProfile, AgentProfileDto>(item);
        //}


    }
}
