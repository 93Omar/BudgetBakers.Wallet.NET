using Newtonsoft.Json;
using Wallet.Api.Net.Dtos;
using System.Collections.Generic;
using Wallet.Api.Net.Dtos.Account;

namespace Wallet.Api.Net.Dtos.Goal
{
    public class GetGoalsResponseDto : PaginatedResponseDto
    {
        [JsonProperty("agentHints")]
        public IList<AgentHintDto> AgentHints { get; set; } = Array.Empty<AgentHintDto>();

        [JsonProperty("goals")]
        public IList<GoalDto> Goals { get; set; } = Array.Empty<GoalDto>();
    }
}
