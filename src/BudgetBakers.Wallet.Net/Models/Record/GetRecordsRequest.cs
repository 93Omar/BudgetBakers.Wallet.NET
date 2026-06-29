using System;
using System.Collections.Generic;
using BudgetBakers.Wallet.Net.Models.Pagination;

namespace BudgetBakers.Wallet.Net.Models.Record
{
    public class GetRecordsRequest : PaginatedRequest
    {
        /// <summary>
        /// Filter by record IDs. Supports up to 30 IDs.
        /// </summary>
        public IList<string> Ids { get; set; } = [];

        /// <summary>
        /// Filter by account ID (exact match). When omitted, returns records from all accounts.
        /// </summary>
        public string? AccountId { get; set; }

        /// <summary>
        /// Filter by transaction date.
        /// Maximal allowed record date range: 370 days.
        /// </summary>
        public DateFilter? RecordDate { get; set; }

        /// <summary>
        /// Enable AI agent hints in response.
        /// </summary>
        public bool AgentHints { get; set; } = false;

        /// <summary>
        /// Filter by category ID (exact match).
        /// </summary>
        public string? CategoryId { get; set; }

        /// <summary>
        /// Filter by label ID - returns records that have this label.
        /// </summary>
        public string? LabelId { get; set; }

        /// <summary>
        /// Filter by note.
        /// </summary>
        public TextFilter? Note { get; set; }

        /// <summary>
        /// Filter records by counter party (payee for expenses, payer for income).
        /// </summary>
        public TextFilter? CounterParty { get; set; }

        /// <summary>
        /// Filter by transaction amount.
        /// </summary>
        public NumberFilter? Amount { get; set; }

        /// <summary>
        /// Filter by creation timestamp.
        /// </summary>
        public DateFilter? CreatedAt { get; set; }

        /// <summary>
        /// Filter by last sync timestamp.
        /// </summary>
        public DateFilter? UpdatedAt { get; set; }

        /// <summary>
        /// Filter by record type (income or expense).
        /// </summary>
        public RecordType? RecordType { get; set; }

        /// <summary>
        /// Filter by payment type.
        /// </summary>
        public PaymentType? PaymentType { get; set; }

        /// <summary>
        /// Filter by record state. Multiple values can be comma-separated.
        /// </summary>
        public RecordState? RecordState { get; set; }

        /// <summary>
        /// Filter by record creation source. Comma-separated values (e.g. "mcp,rest").
        /// Valid values: android, ios, web, rest, mcp, backend, missing.
        /// </summary>
        public string? Source { get; set; }

        /// <summary>
        /// Convert record amounts to the specified currency.
        /// Accepts ISO-4217 code (e.g. "EUR"), "base" (profile currency), or "account" (record's account currency).
        /// </summary>
        public string? ConvertTo { get; set; }

        /// <summary>
        /// Sort results by field.
        /// </summary>
        public RecordSortBy? SortBy { get; set; }
    }
}
