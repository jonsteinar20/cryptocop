using System.Text.Json.Serialization;

namespace Cryptocop.Software.API.Models.Dtos
{
    public class CryptoCurrencyDto
    {
        public int Id { get; set; }
        public string Symbol { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        [JsonPropertyName("price_in_usd")]
        public float? PriceInUsd { get; set; }
        [JsonPropertyName("project_details")]
        public string ProjectDetails { get; set; }
    }
}