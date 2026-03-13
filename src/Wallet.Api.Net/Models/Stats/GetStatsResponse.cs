using Wallet.Api.Net.Models.ResponseInfo;

namespace Wallet.Api.Net.Models.Stats
{
    public class GetStatsResponse : IRateLimitResponse, IDataSynchronizationResponse
    {
        /// <summary>
        /// Rate limit details.
        /// </summary>
        public RateLimitInfo RateLimit { get; set; } = new RateLimitInfo();

        /// <summary>
        /// Data synchronization details.
        /// </summary>
        public DataSynchronizationInfo DataSynchronization { get; set; } = new DataSynchronizationInfo();

        public string? Granularity { get; set; }
        public string? Period { get; set; }
        public int Total { get; set; }
        public IList<StatsUsage> Usage { get; set; } = Array.Empty<StatsUsage>();
    }
}
