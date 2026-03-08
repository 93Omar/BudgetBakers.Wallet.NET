using System.Collections.Generic;
using Wallet.Api.Net.Models.Pagination;

namespace Wallet.Api.Net.Models.Account
{
    public class GetAccountsResponse : PaginatedResponse
    {
        public IList<Account> Accounts { get; set; } = [];
        public IList<AgentHint> AgentHints { get; set; } = [];
    }
}
