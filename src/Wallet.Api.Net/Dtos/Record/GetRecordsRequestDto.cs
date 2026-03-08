using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Wallet.Api.Net.Dtos.Record
{
    public class GetRecordsRequestDto
    {
        [JsonProperty("accountId")]
        public string? AccountId { get; set; }

        [JsonProperty("recordDate")]
        public string? RecordDate { get; set; }

        [JsonProperty("limit")]
        public required int Limit { get; set; }

        [JsonProperty("offset")]
        public required int Offset { get; set; }

        [JsonProperty("agentHints")]
        public bool AgentHints { get; set; }

        [JsonProperty("categoryId")]
        public string? CategoryId { get; set; }

        [JsonProperty("labelId")]
        public string? LabelId { get; set; }

        [JsonProperty("note")]
        public string? Note { get; set; }

        [JsonProperty("payee")]
        public string? Payee { get; set; }

        [JsonProperty("amount")]
        public string? Amount { get; set; }

        [JsonProperty("createdAt")]
        public string? CreatedAt { get; set; }

        [JsonProperty("updatedAt")]
        public string? UpdatedAt { get; set; }

        [JsonProperty("sortBy")]
        public string? SortBy { get; set; }
    }
}
