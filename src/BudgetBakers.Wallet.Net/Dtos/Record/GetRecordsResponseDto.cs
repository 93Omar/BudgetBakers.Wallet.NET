using Newtonsoft.Json;
using System.Collections.Generic;
using BudgetBakers.Wallet.Net.Dtos;
using BudgetBakers.Wallet.Net.Dtos.Account;

namespace BudgetBakers.Wallet.Net.Dtos.Record
{
    internal class GetRecordsResponseDto : PaginatedResponseDto
    {
        [JsonProperty("agentHints")]
        public IList<AgentHintDto> AgentHints { get; set; } = Array.Empty<AgentHintDto>();

        [JsonProperty("recordDateRange")]
        public IList<string> RecordDateRange { get; set; } = Array.Empty<string>();

        [JsonProperty("records")]
        public IList<RecordDto> Records { get; set; } = Array.Empty<RecordDto>();
    }
}

