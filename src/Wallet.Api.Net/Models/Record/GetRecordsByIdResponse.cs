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

        public int Count { get; set; }
        public IList<Record> Records { get; set; } = Array.Empty<Record>();
        public IList<AgentHint> AgentHints { get; set; } = Array.Empty<AgentHint>();
    }
}
