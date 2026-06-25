using Newtonsoft.Json;
using BudgetBakers.Wallet.Net.Dtos;
using System.Collections.Generic;
using BudgetBakers.Wallet.Net.Dtos.Category;

namespace BudgetBakers.Wallet.Net.Dtos.RecordRule
{
    internal class GetRecordRulesResponseDto : PaginatedResponseDto
    {
        [JsonProperty("agentHints")]
        public IList<BudgetBakers.Wallet.Net.Dtos.Account.AgentHintDto> AgentHints { get; set; } = Array.Empty<BudgetBakers.Wallet.Net.Dtos.Account.AgentHintDto>();

        [JsonProperty("recordRules")]
        public IList<RecordRuleDto> RecordRules { get; set; } = Array.Empty<RecordRuleDto>();
    }
}

