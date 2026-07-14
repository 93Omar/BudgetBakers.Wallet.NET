using Newtonsoft.Json;
using BudgetBakers.Wallet.Net.Dtos.Account;

namespace BudgetBakers.Wallet.Net.Dtos.Label
{
    internal class CreateLabelResponseDto
    {
        [JsonProperty("label")]
        public LabelDto? Label { get; set; }

        [JsonProperty("agentHints")]
        public IList<AgentHintDto> AgentHints { get; set; } = [];
    }
}
