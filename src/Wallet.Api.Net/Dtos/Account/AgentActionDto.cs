using Newtonsoft.Json;

namespace Wallet.Api.Net.Dtos.Account
{
    internal class AgentActionDto
    {
        [JsonProperty("url")]
        public string? Url { get; set; }
    }
}

