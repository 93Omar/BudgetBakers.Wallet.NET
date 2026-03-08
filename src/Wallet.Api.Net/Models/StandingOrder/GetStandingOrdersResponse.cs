using System;
using System.Collections.Generic;
using System.Text;
using Wallet.Api.Net.Models.Pagination;

namespace Wallet.Api.Net.Models.StandingOrder
{
    public class GetStandingOrdersResponse : PaginatedResponse
    {
        public IList<StandingOrder> StandingOrders { get; set; } = Array.Empty<StandingOrder>();
        public IList<Models.Account.AgentHint> AgentHints { get; set; } = Array.Empty<Models.Account.AgentHint>();
    }
}
