using Newtonsoft.Json;

namespace Wallet.Api.Net.Dtos
{
    public class BalanceDto
    {
        [JsonProperty("currencyCode")]
        public string? CurrencyCode { get; set; }

        [JsonProperty("value")]
        public decimal Value { get; set; }
    }
}
