using Newtonsoft.Json;
using BudgetBakers.Wallet.Net.Dtos.Account;

namespace BudgetBakers.Wallet.Net.Dtos.Account
{
    internal class UpdateAccountsResponseDto
    {
        [JsonProperty("results")]
        public IList<UpdateAccountResultDto> Results { get; set; } = [];

        [JsonProperty("summary")]
        public BatchOperationSummaryDto? Summary { get; set; }

        [JsonProperty("agentHints")]
        public IList<AgentHintDto> AgentHints { get; set; } = [];
    }
}
