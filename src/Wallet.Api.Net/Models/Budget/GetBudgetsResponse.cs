using System;
using System.Collections.Generic;
using System.Text;
using Wallet.Api.Net.Models.Pagination;
using Wallet.Api.Net.Models.Account;

namespace Wallet.Api.Net.Models.Budget
{
    public class GetBudgetsResponse : PaginatedResponse
    {
        public IList<AgentHint> AgentHints { get; set; } = Array.Empty<AgentHint>();
        public IList<Budget> Budgets { get; set; } = Array.Empty<Budget>();
    }
}
