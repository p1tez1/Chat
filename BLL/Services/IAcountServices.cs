using Chat.Shared.DTOs;
using DAL.Entities;

namespace BLL.Services
{
    public interface IAcountServices
    {
        Task<User> CreateUser(UserDTO dto, CancellationToken cancellationToken);
    }
}