using Newtonsoft.Json;

namespace Wallet.Api.Net.Dtos.Account
{
    public class AgentActionDto
    {
        [JsonProperty("url")]
        public string? Url { get; set; }
    }
}
