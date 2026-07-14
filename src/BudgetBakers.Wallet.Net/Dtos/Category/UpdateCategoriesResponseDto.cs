using Newtonsoft.Json;
using BudgetBakers.Wallet.Net.Dtos.Account;

namespace BudgetBakers.Wallet.Net.Dtos.Category
{
    internal class UpdateCategoriesResponseDto
    {
        [JsonProperty("results")]
        public IList<UpdateCategoryResultDto> Results { get; set; } = [];

        [JsonProperty("summary")]
        public BatchOperationSummaryDto? Summary { get; set; }

        [JsonProperty("agentHints")]
        public IList<AgentHintDto> AgentHints { get; set; } = [];
    }
}
