using System;
using System.Collections.Generic;
using System.Text;
using BudgetBakers.Wallet.Net.Models.Pagination;

namespace BudgetBakers.Wallet.Net.Models.Category
{
    public class GetCategoriesRequest : PaginatedRequest
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
        /// Filter by creation timestamp.
        /// </summary>
        public DateFilter? CreatedAt { get; set; }

        /// <summary>
        /// Filter by last sync timestamp (when entity was last updated in the API database).
        /// </summary>
        public DateFilter? UpdatedAt { get; set; }

        /// <summary>
        /// Filter to only custom (user-created) categories when true, or only system categories when false.
        /// </summary>
        public bool? CustomCategory { get; set; }

        /// <summary>
        /// Filter by archived status.
        /// </summary>
        public bool? Archived { get; set; }

        /// <summary>
        /// Filter categories linked to a specific budget.
        /// </summary>
        public string? BudgetId { get; set; }

        /// <summary>
        /// Sort results by field.
        /// </summary>
        public TimestampSortBy? SortBy { get; set; }
    }
}
