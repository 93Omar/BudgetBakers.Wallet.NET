namespace BudgetBakers.Wallet.Net.Models.ResponseInfo
{
    public class RateLimitInfo
    {
        /// <summary>
        /// Maximum request capacity allowed in the current hourly window.
        /// </summary>
        public int? Limit { get; set; }

        /// <summary>
        /// Remaining request capacity in the current hourly window.
        /// </summary>
        public int? Remaining { get; set; }

        /// <summary>
        /// Number of seconds to wait before retrying when rate-limited.
        /// </summary>
        public int? RetryAfter { get; set; }
    }
}
