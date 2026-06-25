using Newtonsoft.Json;
using System.Collections.Generic;

namespace BudgetBakers.Wallet.Net.Dtos.Budget
{
    internal class BudgetDto
    {
        [JsonProperty("accountIds")]
        public IList<string> AccountIds { get; set; } = Array.Empty<string>();

        [JsonProperty("amount")]
        public string? Amount { get; set; }

        [JsonProperty("categoryIds")]
        public IList<string> CategoryIds { get; set; } = Array.Empty<string>();

        [JsonProperty("createdAt")]
        public string? CreatedAt { get; set; }

        [JsonProperty("currencyCode")]
        public string? CurrencyCode { get; set; }

        [JsonProperty("endDate")]
        public string? EndDate { get; set; }

        [JsonProperty("id")]
        public string? Id { get; set; }

        [JsonProperty("labelIds")]
        public IList<string> LabelIds { get; set; } = Array.Empty<string>();

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("startDate")]
        public string? StartDate { get; set; }

        [JsonProperty("type")]
        public string? Type { get; set; }

        [JsonProperty("updatedAt")]
        public string? UpdatedAt { get; set; }
    }
}

