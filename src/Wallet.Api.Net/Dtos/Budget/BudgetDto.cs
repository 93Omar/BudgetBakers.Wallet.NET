using Newtonsoft.Json;
using System.Collections.Generic;
using Wallet.Api.Net.Dtos.Label;

namespace Wallet.Api.Net.Dtos.Budget
{
    public class BudgetDto
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

        [JsonProperty("labels")]
        public IList<LabelDto> Labels { get; set; } = Array.Empty<LabelDto>();

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
