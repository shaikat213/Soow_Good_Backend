using Microsoft.AspNetCore.SignalR;
using SoowGoodWeb.DtoModels;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus.Distributed;
using Volo.Abp.Ui.Branding;

namespace SoowGoodWeb;

public class ReceivedMessageEventHandler : IDistributedEventHandler<ReceivedNotificationDto>, ITransientDependency
{
    private readonly IHubContext<ChatHub> _hubContext;

    public ReceivedMessageEventHandler(IHubContext<ChatHub> hubContext)
    {
        _hubContext = hubContext;
    }

    public async Task HandleEventAsync(ReceivedNotificationDto eto)
    {
        var message = $"{eto.SenderUserName}: {eto.ReceivedText}";

        await _hubContext.Clients
            .User(eto.TargetUserId.ToString())
            .SendAsync("ReceiveMessage", message);
    }
}
