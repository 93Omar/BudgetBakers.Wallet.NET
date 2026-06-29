using System;
using System.Collections.Generic;
using BudgetBakers.Wallet.Net.Models.Pagination;
using BudgetBakers.Wallet.Net.Models.ResponseInfo;

namespace BudgetBakers.Wallet.Net.Models.StandingOrder
{
    public class GetStandingOrderItemsResponse : IPaginatedResponse, IRateLimitResponse, IDataSynchronizationResponse
    {
        public PaginationInfo Pagination { get; set; } = new PaginationInfo();
        public RateLimitInfo RateLimit { get; set; } = new RateLimitInfo();
        public DataSynchronizationInfo DataSynchronization { get; set; } = new DataSynchronizationInfo();
        public IList<StandingOrderItem> StandingOrderItems { get; set; } = [];
        public IList<AgentHint> AgentHints { get; set; } = [];
    }
}
