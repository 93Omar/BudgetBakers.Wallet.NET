using System;
using System.Collections.Generic;
using Wallet.Api.Net.Models.ResponseInfo;

namespace Wallet.Api.Net.Models.Record
{
    public class GetRecordsByIdResponse : IRateLimitResponse, IDataSynchronizationResponse
    {
        /// <summary>
        /// Rate limit details.
        /// </summary>
        public RateLimitInfo RateLimit { get; set; } = new RateLimitInfo();

        /// <summary>
        /// Data synchronization details.
        /// </summary>
        public DataSynchronizationInfo DataSynchronization { get; set; } = new DataSynchronizationInfo();

        /// <summary>
        /// Number of records returned.
        /// </summary>
        public int Count { get; set; }

        public IList<Record> Records { get; set; } = Array.Empty<Record>();

        /// <summary>
        /// Array of hints for AI agents. Only present when agentHints=true query parameter is set.
        /// </summary>
        public IList<AgentHint> AgentHints { get; set; } = Array.Empty<AgentHint>();
    }
}
