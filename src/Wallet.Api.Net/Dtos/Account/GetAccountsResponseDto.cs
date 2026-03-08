using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Wallet.Api.Net.Dtos.Account
{
    public class GetAccountsResponseDto : PaginatedResponseDto
    {
        [JsonProperty("accounts")]
        public IList<AccountDto> Accounts { get; set; } = Array.Empty<AccountDto>();

        [JsonProperty("agentHints")]
        public IList<AgentHintDto> AgentHints { get; set; } = Array.Empty<AgentHintDto>();
    }
}
