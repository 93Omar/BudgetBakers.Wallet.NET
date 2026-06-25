namespace BudgetBakers.Wallet.Net.Models.Stats
{
    public class StatsUsage
    {
        /// <summary>
        /// Start of period, inclusive.
        /// </summary>
        public DateTime? From { get; set; }

        /// <summary>
        /// End of period, exclusive. This is the start of the next period, so the range is [from, to). For daily granularity, 'to' is 'from' + 1 day.
        /// </summary>
        public DateTime? To { get; set; }

        /// <summary>
        /// Total API requests in this period.
        /// </summary>
        public int Total { get; set; }
    }
}
