using Newtonsoft.Json;

namespace BudgetBakers.Wallet.Net.Dtos.Budget
{
    internal class BudgetChangeEntryDto
    {
        [JsonProperty("createdAt")]
        public string? CreatedAt { get; set; }

        [JsonProperty("limit")]
        public decimal? Limit { get; set; }

        [JsonProperty("period")]
        public string? Period { get; set; }

        [JsonProperty("periodCount")]
        public int? PeriodCount { get; set; }

        [JsonProperty("periodStart")]
        public string? PeriodStart { get; set; }
    }
}
