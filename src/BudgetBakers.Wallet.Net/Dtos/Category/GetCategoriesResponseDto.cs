using Newtonsoft.Json;
using BudgetBakers.Wallet.Net.Dtos;
using BudgetBakers.Wallet.Net.Dtos.Account;
using System.Collections.Generic;

namespace BudgetBakers.Wallet.Net.Dtos.Category
{
    internal class GetCategoriesResponseDto : PaginatedResponseDto
    {
        [JsonProperty("agentHints")]
        public IList<AgentHintDto> AgentHints { get; set; } = Array.Empty<AgentHintDto>();

        [JsonProperty("categories")]
        public IList<CategoryDto> Categories { get; set; } = Array.Empty<CategoryDto>();
    }
}

