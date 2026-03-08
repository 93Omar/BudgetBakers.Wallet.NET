using Newtonsoft.Json;
using System.Collections.Generic;

namespace Wallet.Api.Net.Dtos.Account
{
    public class GetAccountsResponseDto : PaginatedResponseDto
    {
        [JsonProperty("accounts")]
        public IList<AccountDto> Accounts { get; set; } = [];

        [JsonProperty("agentHints")]
        public IList<AgentHintDto> AgentHints { get; set; } = [];
    }
}
