using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Wallet.Api.Net.Dtos.Account;

namespace Wallet.Api.Net.Dtos.Record
{
    public class GetRecordsByIdResponseDto
    {
        [JsonProperty("agentHints")]
        public IList<AgentHintDto> AgentHints { get; set; } = Array.Empty<AgentHintDto>();

        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("records")]
        public IList<RecordDto> Records { get; set; } = Array.Empty<RecordDto>();
    }
}
