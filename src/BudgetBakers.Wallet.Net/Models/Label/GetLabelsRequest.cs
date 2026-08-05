using System;
using System.Collections.Generic;
using System.Text;
using BudgetBakers.Wallet.Net.Models.Pagination;

namespace BudgetBakers.Wallet.Net.Models.Label
{
    public class GetLabelsRequest : PaginatedRequest
    {
        /// <summary>
        /// Enable AI agent hints in response. When true, includes structured hints to help AI agents understand the response and take follow-up actions.
        /// </summary>
        public bool AgentHints { get; set; } = false;

        /// <summary>
        /// Filter by ID.
        /// </summary>
        public IList<string> Ids { get; set; } = [];

        /// <summary>
        /// Filter by name.
        /// </summary>
        public TextFilter? Name { get; set; }

        /// <summary>
        /// Filter by creation timestamp. Up to 2 filters can be provided to combine bounds with AND logic.
        /// </summary>
        public IList<DateFilter> CreatedAt { get; set; } = [];

        /// <summary>
        /// Filter by last sync timestamp (when entity was last updated in the API database). Up to 2 filters
        /// can be provided to combine bounds with AND logic.
        /// </summary>
        public IList<DateFilter> UpdatedAt { get; set; } = [];

        /// <summary>
        /// Filter by archived status.
        /// </summary>
        public bool? Archived { get; set; }

        /// <summary>
        /// Filter labels attached to a specific record.
        /// </summary>
        public string? RecordId { get; set; }

        /// <summary>
        /// Filter labels linked to a specific budget.
        /// </summary>
        public string? BudgetId { get; set; }

        /// <summary>
        /// Filter labels linked to a specific standing order.
        /// </summary>
        public string? StandingOrderId { get; set; }

        /// <summary>
        /// Filter labels linked to a specific record rule.
        /// </summary>
        public string? RecordRuleId { get; set; }

        /// <summary>
        /// Sort results by field.
        /// </summary>
        public TimestampSortBy? SortBy { get; set; }
    }
}
