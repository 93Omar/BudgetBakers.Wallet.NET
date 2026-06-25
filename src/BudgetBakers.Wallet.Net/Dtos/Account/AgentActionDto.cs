using Newtonsoft.Json;

namespace BudgetBakers.Wallet.Net.Dtos.Account
{
    internal class AgentActionDto
    {
        [JsonProperty("url")]
        public string? Url { get; set; }
    }
}

