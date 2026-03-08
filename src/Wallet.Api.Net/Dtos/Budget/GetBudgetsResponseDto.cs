using Newtonsoft.Json;
using System.Collections.Generic;
using Wallet.Api.Net.Dtos;
using Wallet.Api.Net.Dtos.Account;

namespace Wallet.Api.Net.Dtos.Budget
{
    public class GetBudgetsResponseDto : PaginatedResponseDto
    {
        [JsonProperty("agentHints")]
        public IList<AgentHintDto> AgentHints { get; set; } = Array.Empty<AgentHintDto>();

        [JsonProperty("budgets")]
        public IList<BudgetDto> Budgets { get; set; } = Array.Empty<BudgetDto>();
    }
}
