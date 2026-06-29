using Newtonsoft.Json;

namespace BudgetBakers.Wallet.Net.Dtos.Record
{
    internal class ConvertedAmountDto
    {
        [JsonProperty("conversionPair")]
        public string? ConversionPair { get; set; }

        [JsonProperty("currencyCode")]
        public string? CurrencyCode { get; set; }

        [JsonProperty("error")]
        public string? Error { get; set; }

        [JsonProperty("ratio")]
        public double? Ratio { get; set; }

        [JsonProperty("value")]
        public double? Value { get; set; }
    }
}
