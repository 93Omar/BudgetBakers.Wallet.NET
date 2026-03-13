using System;
using System.Collections.Generic;
using Wallet.Api.Net.Models.Pagination;
using Wallet.Api.Net.Models.ResponseInfo;

namespace Wallet.Api.Net.Models.RecordRule
{
    public class GetRecordRulesResponse : IPaginatedResponse, IRateLimitResponse, IDataSynchronizationResponse
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

        public IList<RecordRule> RecordRules { get; set; } = Array.Empty<RecordRule>();
        public IList<AgentHint> AgentHints { get; set; } = Array.Empty<AgentHint>();
    }
}
