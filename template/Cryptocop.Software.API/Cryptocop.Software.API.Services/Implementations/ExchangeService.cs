using System.Net.Http;
using System.Threading.Tasks;
using Cryptocop.Software.API.Models;
using Cryptocop.Software.API.Models.Dtos;
using Cryptocop.Software.API.Services.Interfaces;

namespace Cryptocop.Software.API.Services.Implementations
{
    public class ExchangeService : IExchangeService
    {
        private HttpClient _httpClient;
        public ExchangeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<Envelope<ExchangeDto>> GetExchanges(int pageNumber = 1)
        {
            var response = await _httpClient.GetAsync($"v1/markets?fields=id&page={pageNumber}");
            return null;
        }
    }
}