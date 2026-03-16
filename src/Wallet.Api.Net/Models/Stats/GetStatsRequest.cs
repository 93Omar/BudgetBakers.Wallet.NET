using Wallet.Api.Net.Models;

namespace Wallet.Api.Net.Models.Stats
{
    public class GetStatsRequest
    {
        /// <summary>
        /// Time period for statistics.
        /// </summary>
        public required PeriodFilter Period { get; set; }
    }
}
