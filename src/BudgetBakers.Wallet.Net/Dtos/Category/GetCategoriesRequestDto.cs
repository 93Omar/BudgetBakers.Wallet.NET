using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace BudgetBakers.Wallet.Net.Dtos.Category
{
    internal class GetCategoriesRequestDto
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

        [JsonProperty("customCategory")]
        public bool? CustomCategory { get; set; }

        [JsonProperty("archived")]
        public bool? Archived { get; set; }

        [JsonProperty("budgetId")]
        public string? BudgetId { get; set; }

        [JsonProperty("cardinality")]
        public string? Cardinality { get; set; }

        [JsonProperty("sortBy")]
        public string? SortBy { get; set; }
    }
}

