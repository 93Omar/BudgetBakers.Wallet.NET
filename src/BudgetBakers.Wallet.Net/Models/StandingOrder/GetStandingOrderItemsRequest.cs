using System;
using System.Collections.Generic;
using BudgetBakers.Wallet.Net.Models.Pagination;

namespace BudgetBakers.Wallet.Net.Models.StandingOrder
{
    public class GetStandingOrderItemsRequest : PaginatedRequest
    {
        /// <summary>
        /// Enable AI agent hints in response.
        /// </summary>
        public bool AgentHints { get; set; } = false;

        /// <summary>
        /// Filter items belonging to a specific standing order.
        /// </summary>
        public string? StandingOrderId { get; set; }

        /// <summary>
        /// Filter by original scheduled date. Up to 2 filters can be provided to combine bounds with AND logic.
        /// </summary>
        public IList<DateFilter> OriginalDate { get; set; } = [];

        /// <summary>
        /// Filter by dismissed status.
        /// </summary>
        public bool? Dismissed { get; set; }

        /// <summary>
        /// Filter items linked to a specific record.
        /// </summary>
        public string? RecordId { get; set; }

        /// <summary>
        /// Filter by paid date. Up to 2 filters can be provided to combine bounds with AND logic.
        /// </summary>
        public IList<DateFilter> PaidDate { get; set; } = [];
    }
}
