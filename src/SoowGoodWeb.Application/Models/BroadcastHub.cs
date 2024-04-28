using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using SoowGoodWeb.Interfaces;
//using Volo.Abp.AspNetCore.SignalR;
using Volo.Abp.Users;

namespace SoowGoodWeb
{
    //public class ChatHub : Hub<IHubClient>
    //{
    //}
    //[Authorize]
    public class BroadcastHub : Hub<IHubClient> //: AbpHub
    {
        //private readonly ICurrentUser _currentUser;

        //public ChatHub(ICurrentUser currentUser)
        //{
        //    _currentUser = currentUser;
        //}

        //public override Task OnConnectedAsync()
        //{
        //    return base.OnConnectedAsync();
        //}
    }
}
