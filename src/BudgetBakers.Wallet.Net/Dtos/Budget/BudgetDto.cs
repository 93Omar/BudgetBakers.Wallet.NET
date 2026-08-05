using System.Collections.Generic;
using Newtonsoft.Json;

namespace BudgetBakers.Wallet.Net.Dtos.Budget
{
    internal class BudgetDto
    {
        [JsonProperty("accountIds")]
        public IList<string> AccountIds { get; set; } = [];

        [JsonProperty("limit")]
        public decimal? Limit { get; set; }

        [JsonProperty("closed")]
        public bool? Closed { get; set; }

        [JsonProperty("closedDate")]
        public string? ClosedDate { get; set; }

        [JsonProperty("categoryIds")]
        public IList<string> CategoryIds { get; set; } = [];

        [JsonProperty("createdAt")]
        public string? CreatedAt { get; set; }

        [JsonProperty("currencyCode")]
        public string? CurrencyCode { get; set; }

        [JsonProperty("endDate")]
        public string? EndDate { get; set; }

        [JsonProperty("id")]
        public string? Id { get; set; }

        [JsonProperty("labelIds")]
        public IList<string> LabelIds { get; set; } = [];

        [JsonProperty("limitOverrides")]
        public IList<BudgetChangeEntryDto> LimitOverrides { get; set; } = [];

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("pastLimitOverrides")]
        public IList<BudgetChangeEntryDto> PastLimitOverrides { get; set; } = [];

        [JsonProperty("spending")]
        public BudgetSpendingDto? Spending { get; set; }

        [JsonProperty("startDate")]
        public string? StartDate { get; set; }

        [JsonProperty("type")]
        public string? Type { get; set; }

        [JsonProperty("updatedAt")]
        public string? UpdatedAt { get; set; }
    }
}
