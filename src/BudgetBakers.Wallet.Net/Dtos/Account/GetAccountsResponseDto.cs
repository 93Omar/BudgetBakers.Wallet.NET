using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace BudgetBakers.Wallet.Net.Dtos.Account
{
    internal class GetAccountsResponseDto : PaginatedResponseDto
    {
        [JsonProperty("accounts")]
        public IList<AccountDto> Accounts { get; set; } = [];

        [JsonProperty("agentHints")]
        public IList<AgentHintDto> AgentHints { get; set; } = [];
    }
}
