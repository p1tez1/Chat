using Microsoft.AspNetCore.SignalR;

namespace Chat.Server.Hubs
{
    public interface IChatHubClient
    {
        void RecieveMassage(string message);
    }
    public class ChatHub : Hub
    {
        public ChatHub()
        {
            
        }

        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }
    }
}
