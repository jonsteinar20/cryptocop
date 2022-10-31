using System.Collections.Generic;
using System.Threading.Tasks;
using Cryptocop.Software.API.Models.Dtos;
using Cryptocop.Software.API.Services.Interfaces;
using Cryptocop.Software.API.Services.Helpers;
using System.Net.Http;
using System.Linq;

namespace Cryptocop.Software.API.Services.Implementations
{
    public class CryptoCurrencyService : ICryptoCurrencyService
    {
        private HttpClient _httpClient;
        public CryptoCurrencyService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<CryptoCurrencyDto>> GetAvailableCryptocurrencies()
        {
            var response = await _httpClient.GetAsync("v2/assets?fields=id,symbol,name,slug,metrics/market_data/price_usd,profile/general/overview/project_details&limit=500");
            var json = await HttpResponseMessageExtensions.DeserializeJsonToList<CryptoCurrencyDto>(response, true);

            return json.Where(c => c.Symbol == "BTC" || c.Symbol == "ETH" || c.Symbol == "USDT" || c.Symbol == "XMR");
        }
    }
}