using Newtonsoft.Json;
using Wallet.Api.Net.Dtos;
using System.Collections.Generic;
using Wallet.Api.Net.Dtos.Category;

namespace Wallet.Api.Net.Dtos.RecordRule
{
    public class GetRecordRulesResponseDto : PaginatedResponseDto
    {
        [JsonProperty("agentHints")]
        public IList<Wallet.Api.Net.Dtos.Account.AgentHintDto> AgentHints { get; set; } = Array.Empty<Wallet.Api.Net.Dtos.Account.AgentHintDto>();

        [JsonProperty("recordRules")]
        public IList<RecordRuleDto> RecordRules { get; set; } = Array.Empty<RecordRuleDto>();
    }
}
