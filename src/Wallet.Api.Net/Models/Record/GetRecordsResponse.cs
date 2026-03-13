using System;
using System.Collections.Generic;
using Wallet.Api.Net.Models.Pagination;
using Wallet.Api.Net.Models.ResponseInfo;

namespace Wallet.Api.Net.Models.Record
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

        public IList<string> RecordDateRange { get; set; } = Array.Empty<string>();
        public IList<Record> Records { get; set; } = Array.Empty<Record>();
        public IList<AgentHint> AgentHints { get; set; } = Array.Empty<AgentHint>();
    }
}
