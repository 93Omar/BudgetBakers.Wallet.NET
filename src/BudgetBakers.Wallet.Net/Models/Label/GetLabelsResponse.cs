using System;
using System.Collections.Generic;
using BudgetBakers.Wallet.Net.Models.Pagination;
using BudgetBakers.Wallet.Net.Models.ResponseInfo;

namespace BudgetBakers.Wallet.Net.Models.Label
{
    public class GetLabelsResponse : IPaginatedResponse, IRateLimitResponse, IDataSynchronizationResponse
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

        public IList<Label> Labels { get; set; } = [];

        /// <summary>
        /// Array of hints for AI agents. Only present when agentHints=true query parameter is set.
        /// </summary>
        public IList<AgentHint> AgentHints { get; set; } = [];
    }
}
