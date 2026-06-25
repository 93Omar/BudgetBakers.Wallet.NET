using Newtonsoft.Json;

namespace BudgetBakers.Wallet.Net.Dtos.Account
{
    internal class AgentHintDto
    {
        [JsonProperty("action")]
        public AgentActionDto? Action { get; set; }

        [JsonProperty("data")]
        public object? Data { get; set; }

        [JsonProperty("severity")]
        public string Severity { get; set; } = null!;

        [JsonProperty("text")]
        public string Text { get; set; } = null!;

        [JsonProperty("type")]
        public string Type { get; set; } = null!;
    }
}

