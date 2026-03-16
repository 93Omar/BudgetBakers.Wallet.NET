using System;
using System.Collections.Generic;
using System.Text;
using Wallet.Api.Net.Models.Pagination;

namespace Wallet.Api.Net.Models.Account
{
    public class GetAccountsRequest : PaginatedRequest
    {
        /// <summary>
        /// Enable AI agent hints in response. When true, includes structured hints to help AI agents understand the response and take follow-up actions.
        /// </summary>
        public bool AgentHints { get; set; } = false;

        /// <summary>
        /// Filter by ID.
        /// </summary>
        public IList<string> Ids { get; set; } = Array.Empty<string>();

        /// <summary>
        /// Filter by name.
        /// </summary>
        public TextFilter? Name { get; set; }

        /// <summary>
        /// Filter by bank account number.
        /// </summary>
        public TextFilter? BankAccountNumber { get; set; }

        /// <summary>
        /// Filter accounts by account type.
        /// </summary>
        public AccountType? AccountType { get; set; }

        /// <summary>
        /// Filter by currency code (ISO 4217). Exact match, case-insensitive.
        /// </summary>
        public string? CurrencyCode { get; set; }

        /// <summary>
        /// Filter by creation timestamp.
        /// </summary>
        public DateFilter? CreatedAt { get; set; }

        /// <summary>
        /// Filter by last sync timestamp (when entity was last updated in the API database).
        /// </summary>
        public DateFilter? UpdatedAt { get; set; }
    }
}
