using Newtonsoft.Json;
using System.Collections.Generic;
using BudgetBakers.Wallet.Net.Dtos.Account;

namespace BudgetBakers.Wallet.Net.Dtos.StandingOrder
{
    internal class GetStandingOrderItemsResponseDto : PaginatedResponseDto
    {
        [JsonProperty("standingOrderItems")]
        public IList<StandingOrderItemDto> StandingOrderItems { get; set; } = [];

        [JsonProperty("agentHints")]
        public IList<AgentHintDto> AgentHints { get; set; } = [];
    }
}
