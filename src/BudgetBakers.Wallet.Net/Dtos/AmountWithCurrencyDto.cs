using Newtonsoft.Json;

namespace BudgetBakers.Wallet.Net.Dtos
{
    internal class AmountWithCurrencyDto
    {
        [JsonProperty("currencyCode")]
        public string? CurrencyCode { get; set; }

        [JsonProperty("value")]
        public decimal? Value { get; set; }
    }
}
