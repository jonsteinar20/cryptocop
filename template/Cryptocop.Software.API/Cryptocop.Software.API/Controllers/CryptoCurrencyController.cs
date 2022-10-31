using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Cryptocop.Software.API.Services.Interfaces;

namespace Cryptocop.Software.API.Controllers
{
    [ApiController]
    [Route("api/cryptocurrencies")]
    public class CryptoCurrencyController : ControllerBase
    {
        private readonly ICryptoCurrencyService _cryptoCurrencyService;
        public CryptoCurrencyController(ICryptoCurrencyService cryptoCurrencyService)
        {
            _cryptoCurrencyService = cryptoCurrencyService;
        }
        // TODO: Setup routes

        // Gets all available cryptocurrencies
        [Authorize]
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAvailableCryptocurrencies()
        {
            var response = await _cryptoCurrencyService.GetAvailableCryptocurrencies();
            return Ok(response);
        }
    }
}
