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
        public AcountController(IAcountServices acountservices)
        {
            _acountServices = acountservices;
        }

        public async Task<IActionResult> Register(UserDTO dto, CancellationToken cancellationToken)
        {
            var user = _acountServices.CreateUser(dto,cancellationToken);

            return Ok(user);
        }
    }
}
