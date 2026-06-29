using BudgetBakers.Wallet.Net.Models.ResponseInfo;

namespace BudgetBakers.Wallet.Net.Models.Stats
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

        /// <summary>
        /// Time granularity of the usage entries.
        /// </summary>
        public string? Granularity { get; set; }

        /// <summary>
        /// The requested period.
        /// </summary>
        public string? Period { get; set; }

        /// <summary>
        /// Total API requests in the period.
        /// </summary>
        public int Total { get; set; }

        /// <summary>
        /// Per-period request totals. Periods with zero usage are omitted.
        /// </summary>
        public IList<StatsUsage> Usage { get; set; } = [];
    }
}
