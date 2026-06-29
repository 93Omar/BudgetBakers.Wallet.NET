using Newtonsoft.Json;

namespace BudgetBakers.Wallet.Net.Dtos.StandingOrder
{
    internal class GetStandingOrderItemsRequestDto
    {
        [JsonProperty("limit")]
        public required int Limit { get; set; }

        [JsonProperty("offset")]
        public required int Offset { get; set; }

        [JsonProperty("agentHints")]
        public bool AgentHints { get; set; }

        [JsonProperty("withTotal")]
        public bool WithTotal { get; set; }

        [JsonProperty("standingOrderId")]
        public string? StandingOrderId { get; set; }

        [JsonProperty("originalDate")]
        public string? OriginalDate { get; set; }

        [JsonProperty("dismissed")]
        public bool? Dismissed { get; set; }

        [JsonProperty("recordId")]
        public string? RecordId { get; set; }

        [JsonProperty("paidDate")]
        public string? PaidDate { get; set; }
    }
}
