using Newtonsoft.Json;

namespace BudgetBakers.Wallet.Net.Dtos.Record
{
    internal class RecordAmountDto
    {
        [JsonProperty("value")]
        public double Value { get; set; }

        [JsonProperty("currencyCode")]
        public string? CurrencyCode { get; set; }
    }
}
