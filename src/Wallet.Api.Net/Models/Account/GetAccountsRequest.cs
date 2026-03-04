using System;
using System.Collections.Generic;
using System.Text;
using Wallet.Api.Net.Models.Pagination;

namespace Wallet.Api.Net.Models.Account
{
    public class GetAccountsRequest : PaginatedRequest
    {
        public bool AgentHints { get; set; } = false;
        public IList<string> Ids { get; set; } = [];
        public TextFilter? Name { get; set; }
        public TextFilter? BankAccountNumber { get; set; }
        public AccountType? AccountType { get; set; }
        public string? CurrencyCode { get; set; }
        public DateFilter? CreatedAt { get; set; }
        public DateFilter? UpdatedAt { get; set; }
    }
}
