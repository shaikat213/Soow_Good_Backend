using SoowGoodWeb.DtoModels;
using SoowGoodWeb.InputDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace SoowGoodWeb.Interfaces
{
    public interface INotificationService : IApplicationService
    {
        Task<List<NotificationDto>> GetListAsync();
        Task<NotificationDto> GetAsync(int id);
        Task<int> GetCount();
        //Task<NotificationDto> CreateAsync(DegreeInputDto input);
        //Task<NotificationDto> UpdateAsync(DegreeInputDto input);
    }
}
