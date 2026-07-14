using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace BudgetBakers.Wallet.Net.Dtos.Label
{
    internal class GetLabelsRequestDto
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

        [JsonProperty("createdAt")]
        public string? CreatedAt { get; set; }

        [JsonProperty("updatedAt")]
        public string? UpdatedAt { get; set; }

        [JsonProperty("archived")]
        public bool? Archived { get; set; }

        [JsonProperty("recordId")]
        public string? RecordId { get; set; }

        [JsonProperty("budgetId")]
        public string? BudgetId { get; set; }

        [JsonProperty("standingOrderId")]
        public string? StandingOrderId { get; set; }

        [JsonProperty("recordRuleId")]
        public string? RecordRuleId { get; set; }

        [JsonProperty("sortBy")]
        public string? SortBy { get; set; }
    }
}

