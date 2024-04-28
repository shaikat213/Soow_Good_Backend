using SoowGoodWeb.InputDto;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace SoowGoodWeb.Interfaces
{
    public interface INotificationAppService : IApplicationService
    {
        Task SendNotificationAsync(SendNotificationInputDto input);
    }
}
