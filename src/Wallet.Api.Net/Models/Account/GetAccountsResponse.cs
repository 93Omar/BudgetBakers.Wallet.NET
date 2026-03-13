using System;
using System.Collections.Generic;
using Wallet.Api.Net.Models.Pagination;
using Wallet.Api.Net.Models.ResponseInfo;

namespace Wallet.Api.Net.Models.Account
{
    public class GetAccountsResponse : IPaginatedResponse, IRateLimitResponse, IDataSynchronizationResponse
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

        public IList<Account> Accounts { get; set; } = Array.Empty<Account>();
        public IList<AgentHint> AgentHints { get; set; } = Array.Empty<AgentHint>();
    }
}
