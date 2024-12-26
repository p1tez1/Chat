using AutoMapper;
using Chat.Shared.DTOs;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services
{
    public class AcountServices : IAcountServices
    {
        private readonly ChatContext _chatContext;
        private readonly IMapper _mapper;


        public AcountServices(ChatContext chatContext, IMapper mapper)
        {
            _chatContext = chatContext;
            _mapper = mapper;
        }

        public async Task<User> Register(RegisterDto dto, CancellationToken cancellationToken)
        {
            var usernameExist = await _chatContext.Users.
                                        AsNoTracking().
                                        AnyAsync(u => u.Username == dto.Username, cancellationToken);

            if (usernameExist)
            {
                throw new Exception($"{nameof(dto.Username)} alredy exists");
            }

            var user = _mapper.Map<User>(dto);

            await _chatContext.Users.AddAsync(user, cancellationToken);
            await _chatContext.SaveChangesAsync(cancellationToken);

            return user;
        }

        public async Task<User> Login(LoginDto dto, CancellationToken cancellationToken)
        {
            var user = await _chatContext.Users.FirstOrDefaultAsync(u => u.Username == dto.Username && u.Password == dto.Password, cancellationToken);

            if (user is null)
            {
                throw new Exception("Incorect password or username");
            }

            return user;
        }

    }
}
