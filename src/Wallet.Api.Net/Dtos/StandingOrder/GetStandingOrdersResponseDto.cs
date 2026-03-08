using Newtonsoft.Json;
using Wallet.Api.Net.Dtos;
using System.Collections.Generic;

namespace Wallet.Api.Net.Dtos.StandingOrder
{
    public class GetStandingOrdersResponseDto : PaginatedResponseDto
    {
        [JsonProperty("agentHints")]
        public IList<Wallet.Api.Net.Dtos.Account.AgentHintDto> AgentHints { get; set; } = Array.Empty<Wallet.Api.Net.Dtos.Account.AgentHintDto>();

        [JsonProperty("standingOrders")]
        public IList<StandingOrderDto> StandingOrders { get; set; } = Array.Empty<StandingOrderDto>();
    }
}
