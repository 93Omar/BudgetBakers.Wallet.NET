using System;
using System.Collections.Generic;
using System.Text;
using BudgetBakers.Wallet.Net.Models.Pagination;

namespace BudgetBakers.Wallet.Net.Models.Record
{
    public class GetRecordsRequest : PaginatedRequest
    {
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
        /// Enable AI agent hints in response. When true, includes structured hints to help AI agents understand the response and take follow-up actions.
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
        /// Filter expense records by payee.
        /// </summary>
        public TextFilter? Payee { get; set; }

        /// <summary>
        /// Filter expense records by payer.
        /// </summary>
        public TextFilter? Payer { get; set; }

        /// <summary>
        /// Filter by transaction amount.
        /// </summary>
        public string? Amount { get; set; }

        /// <summary>
        /// Filter by creation timestamp.
        /// </summary>
        public DateFilter? CreatedAt { get; set; }

        /// <summary>
        /// Filter by last sync timestamp (when entity was last updated in the API database).
        /// </summary>
        public DateFilter? UpdatedAt { get; set; }

        /// <summary>
        /// Sort results by field.
        /// </summary>
        public RecordSortBy? SortBy { get; set; }
    }
}
