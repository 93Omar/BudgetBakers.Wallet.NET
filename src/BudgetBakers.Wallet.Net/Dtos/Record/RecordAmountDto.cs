using Newtonsoft.Json;

namespace BudgetBakers.Wallet.Net.Dtos.Record
{
    internal class RecordAmountDto
    {
        [JsonProperty("value")]
        public decimal Value { get; set; }

        [JsonProperty("currencyCode")]
        public string? CurrencyCode { get; set; }
    }
}
