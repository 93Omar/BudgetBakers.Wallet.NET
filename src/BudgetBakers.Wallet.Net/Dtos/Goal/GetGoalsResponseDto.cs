using Newtonsoft.Json;
using BudgetBakers.Wallet.Net.Dtos;
using System.Collections.Generic;
using BudgetBakers.Wallet.Net.Dtos.Account;

namespace BudgetBakers.Wallet.Net.Dtos.Goal
{
    internal class GetGoalsResponseDto : PaginatedResponseDto
    {
        [JsonProperty("agentHints")]
        public IList<AgentHintDto> AgentHints { get; set; } = Array.Empty<AgentHintDto>();

        [JsonProperty("goals")]
        public IList<GoalDto> Goals { get; set; } = Array.Empty<GoalDto>();
    }
}

