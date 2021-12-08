using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using zadanieNexpertis.Services;

namespace zadanieNexpertis.Controllers
{
    [Route("api/currencies")]
    [ApiController]

    public class CurrenciesController : ControllerBase
    {
        private readonly ICurrenciesService _currenciesService;
        
        public CurrenciesController(ICurrenciesService currenciesService)
        {
            _currenciesService = currenciesService;
        }

        [HttpGet("{data:alpha}")]
        public async Task<ActionResult> Get(string data)
        {
            var output = await _currenciesService.GetDataCurrenciesAsync(data);
            return Ok(output);
        }
    }
}
