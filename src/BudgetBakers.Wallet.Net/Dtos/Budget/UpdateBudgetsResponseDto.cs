using Newtonsoft.Json;
using BudgetBakers.Wallet.Net.Dtos.Account;

namespace BudgetBakers.Wallet.Net.Dtos.Budget
{
    internal class UpdateBudgetsResponseDto
    {
        [JsonProperty("results")]
        public IList<UpdateBudgetResultDto> Results { get; set; } = [];

        [JsonProperty("summary")]
        public BatchOperationSummaryDto? Summary { get; set; }

        [JsonProperty("agentHints")]
        public IList<AgentHintDto> AgentHints { get; set; } = [];
    }
}
