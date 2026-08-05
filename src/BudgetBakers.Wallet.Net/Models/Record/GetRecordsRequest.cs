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
        /// Filter by account ID(s) (max 10). When omitted, returns records from all accounts.
        /// </summary>
        public IList<string> AccountIds { get; set; } = [];

        /// <summary>
        /// Filter by transaction date. Up to 2 filters can be provided to combine bounds with AND logic
        /// (e.g. a lower and an upper bound to express a date range such as "last 3 days" or "last month").
        /// Maximal allowed record date range: 370 days.
        /// </summary>
        public IList<DateFilter> RecordDate { get; set; } = [];

        /// <summary>
        /// Enable AI agent hints in response.
        /// </summary>
        public bool AgentHints { get; set; } = false;

        /// <summary>
        /// Filter by category ID. Matches records in any of the specified categories. The special value
        /// "unknown" expands to the IDs of the 3 built-in categories: Unknown income, Unknown expense, and
        /// Uncategorized. Max 10 values.
        /// </summary>
        public IList<string> CategoryIds { get; set; } = [];

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
        /// Filter by transaction amount. Up to 2 filters can be provided to combine bounds with AND logic
        /// (e.g. a lower and an upper bound to express an amount range).
        /// </summary>
        public IList<NumberFilter> Amount { get; set; } = [];

        /// <summary>
        /// Filter by creation timestamp. Up to 2 filters can be provided to combine bounds with AND logic.
        /// </summary>
        public IList<DateFilter> CreatedAt { get; set; } = [];

        /// <summary>
        /// Filter by last sync timestamp. Up to 2 filters can be provided to combine bounds with AND logic.
        /// </summary>
        public IList<DateFilter> UpdatedAt { get; set; } = [];

        /// <summary>
        /// Filter by record type. Matches on the amount sign (expense = amount &lt; 0, income = amount &gt; 0);
        /// a legacy record with an amount of exactly 0 matches the type it was stored with.
        /// </summary>
        public RecordType? RecordType { get; set; }

        /// <summary>
        /// Filter by transfer state: true = only transfer records (paired or unpaired), false = only non-transfer
        /// records, omit = all. Independent of <see cref="RecordType"/>.
        /// </summary>
        public bool? IsTransfer { get; set; }

        /// <summary>
        /// Filter by transfer identity/identities, as returned in transfer.transferId. Returns every record
        /// sharing any of them: both legs of a pair, or the single record of an unpaired transfer.
        /// </summary>
        public IList<string> TransferIds { get; set; } = [];

        /// <summary>
        /// Filter by record state. Matches records in any of the specified states.
        /// </summary>
        public IList<RecordState> RecordStates { get; set; } = [];

        /// <summary>
        /// Filter by record creation source. Matches records from any of the specified sources.
        /// Valid values: android, ios, web, rest, mcp, backend, missing.
        /// </summary>
        public IList<string> Sources { get; set; } = [];

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
