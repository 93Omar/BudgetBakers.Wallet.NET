using Newtonsoft.Json;

namespace BudgetBakers.Wallet.Net.Dtos.References
{
    internal class ReferencesEntryDto
    {
        [JsonProperty("budgets")]
        public ReferenceResultDto? Budgets { get; set; }

        [JsonProperty("recordRules")]
        public ReferenceResultDto? RecordRules { get; set; }

        [JsonProperty("records")]
        public ReferenceResultDto? Records { get; set; }

        [JsonProperty("standingOrders")]
        public ReferenceResultDto? StandingOrders { get; set; }

        [JsonProperty("error")]
        public string? Error { get; set; }

        [JsonProperty("message")]
        public string? Message { get; set; }

        [JsonProperty("actualType")]
        public string? ActualType { get; set; }
    }
}
