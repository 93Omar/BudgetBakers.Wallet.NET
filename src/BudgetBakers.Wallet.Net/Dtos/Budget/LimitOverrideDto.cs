using Newtonsoft.Json;

namespace BudgetBakers.Wallet.Net.Dtos.Budget
{
    internal class LimitOverrideDto
    {
        [JsonProperty("period")]
        public required string Period { get; set; }

        [JsonProperty("limit")]
        public decimal? Limit { get; set; }

        [JsonProperty("setBaseline")]
        public bool? SetBaseline { get; set; }
    }
}
