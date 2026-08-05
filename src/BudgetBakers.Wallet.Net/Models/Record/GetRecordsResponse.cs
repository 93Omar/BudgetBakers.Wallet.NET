using System;
using System.Collections.Generic;
using BudgetBakers.Wallet.Net.Models.Pagination;
using BudgetBakers.Wallet.Net.Models.ResponseInfo;

namespace BudgetBakers.Wallet.Net.Models.Record
{
    public class GetRecordsResponse : IPaginatedResponse, IRateLimitResponse, IDataSynchronizationResponse
    {
        /// <summary>
        /// Pagination details.
        /// </summary>
        public PaginationInfo Pagination { get; set; } = new PaginationInfo();

        /// <summary>
        /// Rate limit details.
        /// </summary>
        public RateLimitInfo RateLimit { get; set; } = new RateLimitInfo();

        /// <summary>
        /// Data synchronization details.
        /// </summary>
        public DataSynchronizationInfo DataSynchronization { get; set; } = new DataSynchronizationInfo();

        /// <summary>
        /// The actual record date filter applied to this request, as parsed range filters (e.g. a lower and an
        /// upper bound), including the implicit 3-month default window when no explicit filter was provided.
        /// Empty when no date filter is applied (e.g. an ID-based lookup).
        /// </summary>
        public IList<DateFilter> AppliedRecordDateFilters { get; set; } = [];


        public IList<Record> Records { get; set; } = [];

        /// <summary>
        /// Array of hints for AI agents. Only present when agentHints=true query parameter is set.
        /// </summary>
        public IList<AgentHint> AgentHints { get; set; } = [];
    }
}
