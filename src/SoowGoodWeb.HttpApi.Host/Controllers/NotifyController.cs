using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SoowGoodWeb.InputDto;
using SoowGoodWeb.Interfaces;
using Volo.Abp.AspNetCore.Mvc;

namespace SoowGoodWeb.Controllers
{
    [Route("api/app/chat")]
    [ApiController]
    public class NotifyController : AbpController, INotificationAppService
    {
        private readonly INotificationAppService _chatAppService;

        public NotifyController(INotificationAppService chatAppService)
        {
            _chatAppService = chatAppService;
        }

        [HttpPost]
        [Route("send-message")]
        public async Task SendNotificationAsync(SendNotificationInputDto input)
        {
            await _chatAppService.SendNotificationAsync(input);
        }
    }
}
