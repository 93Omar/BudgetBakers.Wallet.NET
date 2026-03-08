using Newtonsoft.Json;
using System.Collections.Generic;
using Wallet.Api.Net.Dtos;

namespace Wallet.Api.Net.Dtos.Record
{
    public class GetRecordsResponseDto : PaginatedResponseDto
    {
        [JsonProperty("agentHints")]
        public IList<Wallet.Api.Net.Dtos.Account.AgentHintDto> AgentHints { get; set; } = Array.Empty<Wallet.Api.Net.Dtos.Account.AgentHintDto>();

        [JsonProperty("recordDateRange")]
        public IList<string> RecordDateRange { get; set; } = Array.Empty<string>();

        [JsonProperty("records")]
        public IList<RecordDto> Records { get; set; } = Array.Empty<RecordDto>();
    }
}
