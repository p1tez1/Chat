using Chat.Shared;
using Chat.Shared.DTOs;
using Microsoft.AspNetCore.SignalR;
using UserDTO;

namespace Chat.Server.Hubs
{
    public class ChatHub : Hub<IChatHubClient>, IChatHubServer
    {
        private static readonly IDictionary<Guid ,UserDto> _connectedUsers = new Dictionary<Guid, UserDto>();
        public ChatHub()
        {
            
        }

        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }

        public async Task ConnectUser(UserDto user)
        {
            await Clients.Caller.ConnectedUsersList(_connectedUsers.Values);

            if(!_connectedUsers.ContainsKey(user.Id))
            {
                _connectedUsers.Add(user.Id, user);

                await Clients.Others.UserConnected(user);
            }
        }
    }
}
