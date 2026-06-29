using Newtonsoft.Json;
using BudgetBakers.Wallet.Net.Dtos;
using System.Collections.Generic;

namespace BudgetBakers.Wallet.Net.Dtos.StandingOrder
{
    internal class GetStandingOrdersResponseDto : PaginatedResponseDto
    {
        [JsonProperty("agentHints")]
        public IList<BudgetBakers.Wallet.Net.Dtos.Account.AgentHintDto> AgentHints { get; set; } = [];

        [JsonProperty("standingOrders")]
        public IList<StandingOrderDto> StandingOrders { get; set; } = [];
    }
}

