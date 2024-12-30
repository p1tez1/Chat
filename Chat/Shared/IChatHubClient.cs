using Chat.Shared.DTOs;
using UserDTO;

namespace Chat.Shared
{
    public interface IChatHubClient
    {
        Task UserConnected(UserDto user);
        Task ConnectedUsersList(IEnumerable<UserDto> users);
    }
}
