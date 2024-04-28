using SoowGoodWeb.DtoModels;
using SoowGoodWeb.Interfaces;
using SoowGoodWeb.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Uow;

namespace SoowGoodWeb.Services
{
    public class DoctorScheduleDaySessionService : SoowGoodWebAppService, IDoctorScheduleDaySessionService//, IDoctorScheduleDayOffService
    {
        
        private readonly IRepository<DoctorScheduleDaySession> _doctorScheduleSessionRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        public DoctorScheduleDaySessionService(IRepository<DoctorScheduleDaySession> doctorScheduleSessionRepository, IUnitOfWorkManager unitOfWorkManager)
        {            
            _doctorScheduleSessionRepository = doctorScheduleSessionRepository;
            _unitOfWorkManager = unitOfWorkManager;
        }
        public async Task<ResponseDto> CreateSessionAsync(DoctorScheduleDaySessionInputDto input)
        {
            var response = new ResponseDto();
            try
            {
                var newEntity = ObjectMapper.Map<DoctorScheduleDaySessionInputDto, DoctorScheduleDaySession>(input);

                var doctorSchedule = await _doctorScheduleSessionRepository.InsertAsync(newEntity);
                await _unitOfWorkManager.Current.SaveChangesAsync();
                var result = ObjectMapper.Map<DoctorScheduleDaySession, DoctorScheduleDaySessionDto>(doctorSchedule);
                if (result != null && result.Id > 0)
                {   
                    response.Id = result?.Id;
                    response.Value = "Schedule Session created";
                    response.Success = true;
                    response.Message = ("Doctor Schedule Session created successfully.");
                }
                else
                {
                    response.Id = 0;
                    response.Value = "Schedule Session creation failed";
                    response.Success = false;
                    response.Message = ("Doctor Schedule Session creation failed.");
                }
            }
            catch (Exception ex)
            {
                response.Id = null;
                response.Value = "Exception";
                response.Success = false;
                response.Message= ex.Message;
            }
            return response;
        }


        public async Task<DoctorScheduleDaySessionDto> GetSessionAsync(int id)
        {
            var item = await _doctorScheduleSessionRepository.GetAsync(x => x.Id == id);

            return ObjectMapper.Map<DoctorScheduleDaySession, DoctorScheduleDaySessionDto>(item);
        }
        public async Task<List<DoctorScheduleDaySessionDto>> GetSessionListAsync()
        {
            var profiles = await _doctorScheduleSessionRepository.GetListAsync();
            return ObjectMapper.Map<List<DoctorScheduleDaySession>, List<DoctorScheduleDaySessionDto>>(profiles);
        }

        //public async Task<DoctorScheduleDto> GetByUserIdAsync(Guid userId)
        //{
        //    var item = await _doctorScheduleRepository.GetAsync(x => x.UserId == userId);
        //    return ObjectMapper.Map<DoctorSchedule, DoctorScheduleDto>(item);
        //}        

        public async Task<ResponseDto> UpdateSessionAsync(DoctorScheduleDaySessionInputDto input)
        {
            var response = new ResponseDto();
            try
            {
                var updateItem = ObjectMapper.Map<DoctorScheduleDaySessionInputDto, DoctorScheduleDaySession>(input);

                var item = await _doctorScheduleSessionRepository.UpdateAsync(updateItem);
                await _unitOfWorkManager.Current.SaveChangesAsync();

                var result = ObjectMapper.Map<DoctorScheduleDaySession, DoctorScheduleDaySessionDto>(item);

                if (result != null && result.Id > 0)
                {
                    response.Id = result?.Id;
                    response.Value = "Schedule Session Updated";
                    response.Success = true;
                    response.Message = ("Doctor Schedule Session updated.");
                }
                else
                {
                    response.Id = 0;
                    response.Value = "Schedule Session update failed";
                    response.Success = false;
                    response.Message = ("Doctor Schedule Session update failed.");
                }
            }
            catch (Exception ex)
            {
                response.Id = null;
                response.Value = "Exception";
                response.Success = false;
                response.Message =(ex.Message);
            }
            return response;
        }
        
    }
}
