using BLL.Features.Heshing;
using BLL.Services;
using Chat.Shared.DTOs;
using DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Chat.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcountController : ControllerBase
    {
        private readonly IAcountServices _acountServices;
        private readonly IHeshing _heshing;
       
        public AcountController(IAcountServices acountservices, IHeshing heshing)
        {
            _acountServices = acountservices;      
            _heshing = heshing;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto dto, CancellationToken cancellationToken)
        {
            var user = _acountServices.Register(dto,cancellationToken);

            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto, CancellationToken cancellationToken)
        {
            var user = _acountServices.Login(dto,cancellationToken);

            return Ok(user);
        }
    }
}
