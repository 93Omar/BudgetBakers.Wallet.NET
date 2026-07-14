using Newtonsoft.Json;
using System.Collections.Generic;
using BudgetBakers.Wallet.Net.Dtos;
using BudgetBakers.Wallet.Net.Dtos.Account;

namespace BudgetBakers.Wallet.Net.Dtos.Budget
{
    internal class GetBudgetsResponseDto : PaginatedResponseDto
    {
        [JsonProperty("agentHints")]
        public IList<AgentHintDto> AgentHints { get; set; } = [];

        [JsonProperty("budgets")]
        public IList<BudgetDto> Budgets { get; set; } = [];
    }
}

