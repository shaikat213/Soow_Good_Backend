using SoowGoodWeb.DtoModels;
using SoowGoodWeb.InputDto;
using SoowGoodWeb.Interfaces;
using SoowGoodWeb.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;
using Volo.Abp.Uow;

namespace SoowGoodWeb.Services
{
    public class UserDataDeleteService : SoowGoodWebAppService, IDeleteAccountService
    {
        private readonly IRepository<UserDataDeleteRequest> _userDataDeleteRequestRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public UserDataDeleteService(IRepository<UserDataDeleteRequest> userDataDeleteRequestRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _userDataDeleteRequestRepository = userDataDeleteRequestRepository;

            _unitOfWorkManager = unitOfWorkManager;
        }
        public async Task<UserDataDeleteRequestDto> CreateAsync(UserDataDeleteRequestInputDto input)
        {
            var newEntity = ObjectMapper.Map<UserDataDeleteRequestInputDto, UserDataDeleteRequest>(input);

            var userDataDeleteRequest = await _userDataDeleteRequestRepository.InsertAsync(newEntity);

            await _unitOfWorkManager.Current.SaveChangesAsync();

            return ObjectMapper.Map<UserDataDeleteRequest, UserDataDeleteRequestDto>(userDataDeleteRequest);
        }

        public async Task<UserDataDeleteRequestDto> UpdateAsync(UserDataDeleteRequestInputDto input)
        {
            var updateItem = ObjectMapper.Map<UserDataDeleteRequestInputDto, UserDataDeleteRequest>(input);

            var item = await _userDataDeleteRequestRepository.UpdateAsync(updateItem);

            await _unitOfWorkManager.Current.SaveChangesAsync();

            return ObjectMapper.Map<UserDataDeleteRequest, UserDataDeleteRequestDto>(item);
        }


        public async Task<UserDataDeleteRequestDto> GetAsync(int id)
        {
            var item = await _userDataDeleteRequestRepository.GetAsync(x => x.Id == id);

            return ObjectMapper.Map<UserDataDeleteRequest, UserDataDeleteRequestDto>(item);
        }
        public async Task<List<UserDataDeleteRequestDto>> GetListAsync()
        {
            var userDataDeleteRequests = await _userDataDeleteRequestRepository.GetListAsync();
            return ObjectMapper.Map<List<UserDataDeleteRequest>, List<UserDataDeleteRequestDto>>(userDataDeleteRequests);
        }

    }
}
