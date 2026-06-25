using System;
using System.Collections.Generic;
using BudgetBakers.Wallet.Net.Models.Pagination;
using BudgetBakers.Wallet.Net.Models.ResponseInfo;

namespace BudgetBakers.Wallet.Net.Models.Goal
{
    public class GetGoalsResponse : IPaginatedResponse, IRateLimitResponse, IDataSynchronizationResponse
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

        public IList<Goal> Goals { get; set; } = Array.Empty<Goal>();

        /// <summary>
        /// Array of hints for AI agents. Only present when agentHints=true query parameter is set.
        /// </summary>
        public IList<AgentHint> AgentHints { get; set; } = Array.Empty<AgentHint>();
    }
}
