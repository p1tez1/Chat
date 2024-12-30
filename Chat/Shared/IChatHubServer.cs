using Chat.Shared.DTOs;
using UserDTO;

namespace Chat.Shared
{

    public interface IChatHubServer
    {
        Task ConnectUser(UserDto user);
    }
}
