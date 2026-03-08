using Newtonsoft.Json;

namespace Wallet.Api.Net.Dtos.Account
{
    public class AgentHintDto
    {
        [JsonProperty("action")]
        public AgentActionDto? Action { get; set; }

        [JsonProperty("data")]
        public object? Data { get; set; }

        [JsonProperty("severity")]
        public string? Severity { get; set; }

        [JsonProperty("text")]
        public string? Text { get; set; }

        [JsonProperty("type")]
        public string? Type { get; set; }
    }
}
