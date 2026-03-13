using System;
using System.Collections.Generic;
using System.Text;
using Wallet.Api.Net.Models.Pagination;

namespace Wallet.Api.Net.Models.Goal
{
    public class GetGoalsRequest : PaginatedRequest
    {
        public bool AgentHints { get; set; } = false;
        public IList<string> Ids { get; set; } = Array.Empty<string>();
        public TextFilter? Name { get; set; }
        public TextFilter? Note { get; set; }
        public DateFilter? CreatedAt { get; set; }
        public DateFilter? UpdatedAt { get; set; }
    }
}
