using Chat.Shared.DTOs;
using DAL.Entities;

namespace BLL.Services
{
    public interface IAcountServices
    {
        Task<User> Register(RegisterDto dto, CancellationToken cancellationToken);
        Task<User> Login(LoginDto dto, CancellationToken cancellationToken);
    }
}