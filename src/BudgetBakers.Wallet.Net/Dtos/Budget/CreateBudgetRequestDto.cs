using Newtonsoft.Json;

namespace BudgetBakers.Wallet.Net.Dtos.Budget
{
    internal class CreateBudgetRequestDto
    {
        [JsonProperty("name")]
        public required string Name { get; set; }

        [JsonProperty("currencyCode")]
        public required string CurrencyCode { get; set; }

        [JsonProperty("type")]
        public required string Type { get; set; }

        [JsonProperty("limit")]
        public double Limit { get; set; }

        [JsonProperty("accountIds")]
        public IList<string>? AccountIds { get; set; }

        [JsonProperty("categoryIds")]
        public IList<string>? CategoryIds { get; set; }

        [JsonProperty("labelIds")]
        public IList<string>? LabelIds { get; set; }

        [JsonProperty("startDate")]
        public string? StartDate { get; set; }

        [JsonProperty("endDate")]
        public string? EndDate { get; set; }
    }
}
