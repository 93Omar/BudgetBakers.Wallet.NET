using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace BudgetBakers.Wallet.Net.Dtos.Record
{
    internal class GetRecordsRequestDto
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

        [JsonProperty("withTotal")]
        public bool WithTotal { get; set; }

        [JsonProperty("categoryId")]
        public string? CategoryId { get; set; }

        [JsonProperty("labelId")]
        public string? LabelId { get; set; }

        [JsonProperty("note")]
        public string? Note { get; set; }

        [JsonProperty("counterParty")]
        public string? CounterParty { get; set; }

        [JsonProperty("amount")]
        public string? Amount { get; set; }

        [JsonProperty("createdAt")]
        public string? CreatedAt { get; set; }

        [JsonProperty("updatedAt")]
        public string? UpdatedAt { get; set; }

        [JsonProperty("sortBy")]
        public string? SortBy { get; set; }

        [JsonProperty("id")]
        public string? Id { get; set; }

        [JsonProperty("recordType")]
        public string? RecordType { get; set; }

        [JsonProperty("paymentType")]
        public string? PaymentType { get; set; }

        [JsonProperty("recordState")]
        public string? RecordState { get; set; }

        [JsonProperty("source")]
        public string? Source { get; set; }

        [JsonProperty("convertTo")]
        public string? ConvertTo { get; set; }
    }
}

