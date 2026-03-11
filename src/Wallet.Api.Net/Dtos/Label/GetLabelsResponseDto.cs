using Newtonsoft.Json;
using Wallet.Api.Net.Dtos;
using Wallet.Api.Net.Dtos.Account;
using System.Collections.Generic;

namespace Wallet.Api.Net.Dtos.Label
{
    internal class GetLabelsResponseDto : PaginatedResponseDto
    {
        [JsonProperty("agentHints")]
        public IList<AgentHintDto> AgentHints { get; set; } = Array.Empty<AgentHintDto>();

        [JsonProperty("labels")]
        public IList<LabelDto> Labels { get; set; } = Array.Empty<LabelDto>();
    }
}

