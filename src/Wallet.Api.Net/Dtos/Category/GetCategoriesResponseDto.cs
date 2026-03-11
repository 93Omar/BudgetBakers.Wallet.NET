using Newtonsoft.Json;
using Wallet.Api.Net.Dtos;
using Wallet.Api.Net.Dtos.Account;
using System.Collections.Generic;

namespace Wallet.Api.Net.Dtos.Category
{
    internal class GetCategoriesResponseDto : PaginatedResponseDto
    {
        [JsonProperty("agentHints")]
        public IList<AgentHintDto> AgentHints { get; set; } = Array.Empty<AgentHintDto>();

        [JsonProperty("categories")]
        public IList<CategoryDto> Categories { get; set; } = Array.Empty<CategoryDto>();
    }
}

