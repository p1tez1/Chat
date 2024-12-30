using BLL.Features.Heshing;
using BLL.Features.Token;
using BLL.Services;
using Chat.Shared.DTOs;
using DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserDTO;

namespace Chat.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcountController : ControllerBase
    {
        private readonly IAcountServices _acountServices;
        private readonly IHeshing _heshing;
        private readonly TokenService _tokenService;

        public AcountController(IAcountServices acountservices, IHeshing heshing, TokenService tokenService)
        {
            _acountServices = acountservices;      
            _heshing = heshing;
            _tokenService = tokenService;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto dto, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _acountServices.Register(dto, cancellationToken);

                return Ok(GenerateToken(user));
            }
            catch (Exception ex) 
            {
                return StatusCode(500, "This user allredy exist");
            }

            
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _acountServices.Login(dto, cancellationToken);
               
                return Ok(GenerateToken(user));
            }
            catch (Exception ex)            
            {
               
                return StatusCode(500, "Incorect password or username");
                
            }
        }

        private AuthResponseDto GenerateToken(User user)
        {
            var token = _tokenService.GenerateJWT(user);

            return new AuthResponseDto(new UserDto(user.Id, user.Name), token);
        }
    }
}
