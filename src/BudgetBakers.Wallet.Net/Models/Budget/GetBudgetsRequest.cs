using System.Collections.Generic;
using BudgetBakers.Wallet.Net.Models.Pagination;

namespace BudgetBakers.Wallet.Net.Models.Budget
{
    public class GetBudgetsRequest : PaginatedRequest
    {
        public bool AgentHints { get; set; } = false;
        public IList<string> Ids { get; set; } = [];
        public TextFilter? Name { get; set; }
        public string? CurrencyCode { get; set; }
        public bool? Closed { get; set; }
        public BudgetType? Type { get; set; }
        public string? LabelId { get; set; }
        public string? AccountId { get; set; }
        public string? CategoryId { get; set; }
        public DateOnlyFilter? StartDate { get; set; }
        public DateOnlyFilter? EndDate { get; set; }
        public BudgetSpendingDepth? Spending { get; set; }
        public DateFilter? CreatedAt { get; set; }
        public DateFilter? UpdatedAt { get; set; }
    }
}
