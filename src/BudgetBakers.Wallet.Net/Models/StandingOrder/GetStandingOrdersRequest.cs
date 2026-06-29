using System.Collections.Generic;
using BudgetBakers.Wallet.Net.Models.Pagination;

namespace BudgetBakers.Wallet.Net.Models.StandingOrder
{
    public class GetStandingOrdersRequest : PaginatedRequest
    {
        public bool AgentHints { get; set; } = false;
        public IList<string> Ids { get; set; } = [];
        public TextFilter? Name { get; set; }
        public string? CurrencyCode { get; set; }
        public DateFilter? CreatedAt { get; set; }
        public DateFilter? UpdatedAt { get; set; }
        public string? LabelId { get; set; }
    }
}
