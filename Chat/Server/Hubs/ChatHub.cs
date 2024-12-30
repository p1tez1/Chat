using Chat.Shared;
using Microsoft.AspNetCore.SignalR;

namespace Chat.Server.Hubs
{

    
    public class ChatHub : Hub<IChatHubClient>, IChatHubServer
    {
        private static readonly ICollection<string> _connectedUsers = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        public ChatHub()
        {
            
        }

        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }

        public async Task ConnectUser(string userName)
        {
            await Clients.Caller.ConnectedUsersList(_connectedUsers);

            if(!_connectedUsers.Contains(userName))
            {
                _connectedUsers.Add(userName);

                await Clients.Others.UserConnected(userName);
            }
        }
    }
}
