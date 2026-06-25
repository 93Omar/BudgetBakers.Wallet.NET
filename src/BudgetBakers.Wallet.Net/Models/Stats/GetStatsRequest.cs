using BudgetBakers.Wallet.Net.Models;

namespace BudgetBakers.Wallet.Net.Models.Stats
{
    public class GetStatsRequest
    {
        /// <summary>
        /// Time period for statistics.
        /// </summary>
        public required PeriodFilter Period { get; set; }
    }
}
