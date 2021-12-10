using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using zadanieNexpertis.ModelsDto;
using zadanieNexpertis.Services;

namespace zadanieNexpertis.Controllers
{
    [Route("api/user")]
    [ApiController]
    
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] LoginDto dto)
        {
            string token = await _accountService.GenerateJwtAsync(dto);
            return Ok(token);
        }
    }
}
