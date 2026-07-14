using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace BudgetBakers.Wallet.Net.Dtos.Budget
{
    internal class GetBudgetsRequestDto
    {
        [JsonProperty("limit")]
        public required int Limit { get; set; }

        [JsonProperty("offset")]
        public required int Offset { get; set; }

        [JsonProperty("agentHints")]
        public bool AgentHints { get; set; }

        [JsonProperty("withTotal")]
        public bool WithTotal { get; set; }

        [JsonProperty("id")]
        public string? Id { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("currencyCode")]
        public string? CurrencyCode { get; set; }

        [JsonProperty("createdAt")]
        public string? CreatedAt { get; set; }

        [JsonProperty("updatedAt")]
        public string? UpdatedAt { get; set; }

        [JsonProperty("closed")]
        public bool? Closed { get; set; }

        [JsonProperty("type")]
        public string? Type { get; set; }

        [JsonProperty("labelId")]
        public string? LabelId { get; set; }

        [JsonProperty("accountId")]
        public string? AccountId { get; set; }

        [JsonProperty("categoryId")]
        public string? CategoryId { get; set; }

        [JsonProperty("startDate")]
        public string? StartDate { get; set; }

        [JsonProperty("endDate")]
        public string? EndDate { get; set; }

        [JsonProperty("spending")]
        public string? Spending { get; set; }
    }
}

