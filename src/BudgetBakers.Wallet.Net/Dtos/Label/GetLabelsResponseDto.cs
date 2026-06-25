using Newtonsoft.Json;
using BudgetBakers.Wallet.Net.Dtos;
using BudgetBakers.Wallet.Net.Dtos.Account;
using System.Collections.Generic;

namespace BudgetBakers.Wallet.Net.Dtos.Label
{
    internal class GetLabelsResponseDto : PaginatedResponseDto
    {
        [JsonProperty("agentHints")]
        public IList<AgentHintDto> AgentHints { get; set; } = Array.Empty<AgentHintDto>();

        [JsonProperty("labels")]
        public IList<LabelDto> Labels { get; set; } = Array.Empty<LabelDto>();
    }
}

