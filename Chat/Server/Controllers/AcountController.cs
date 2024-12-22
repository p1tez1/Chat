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

        public async Task<IActionResult> Register(UserDTO dto, CancellationToken cancellationToken)
        {
            dto.Password = _heshing.Hash(dto.Password);
            var user = _acountServices.CreateUser(dto,cancellationToken);

            return Ok(user);
        }
    }
}
