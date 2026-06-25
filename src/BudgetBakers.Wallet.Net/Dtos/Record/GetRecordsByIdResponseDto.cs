using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using BudgetBakers.Wallet.Net.Dtos.Account;

namespace BudgetBakers.Wallet.Net.Dtos.Record
{
    internal class GetRecordsByIdResponseDto
    {
        [JsonProperty("agentHints")]
        public IList<AgentHintDto> AgentHints { get; set; } = Array.Empty<AgentHintDto>();

        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("records")]
        public IList<RecordDto> Records { get; set; } = Array.Empty<RecordDto>();
    }
}

