using Newtonsoft.Json;
using BudgetBakers.Wallet.Net.Dtos.Account;

namespace BudgetBakers.Wallet.Net.Dtos.Account
{
    internal class CreateAccountResponseDto
    {
        [JsonProperty("account")]
        public AccountDto? Account { get; set; }

        [JsonProperty("agentHints")]
        public IList<AgentHintDto> AgentHints { get; set; } = [];
    }
}
