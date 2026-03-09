using System;
using System.Collections.Generic;
using System.Text;
using Wallet.Api.Net.Models.Pagination;

namespace Wallet.Api.Net.Models.Category
{
    public class GetCategoriesResponse : PaginatedResponse
    {
        public IList<Category> Categories { get; set; } = Array.Empty<Category>();
        public IList<AgentHint> AgentHints { get; set; } = Array.Empty<AgentHint>();
    }
}
