using Microsoft.AspNetCore.Mvc;
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
        public ActionResult Login([FromBody] LoginDto dto)
        {
            string token = _accountService.GenerateJwt(dto);
            return Ok(token);
        }
    }
}
