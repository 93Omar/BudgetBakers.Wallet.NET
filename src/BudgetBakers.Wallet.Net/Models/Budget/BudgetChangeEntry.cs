using System;

namespace BudgetBakers.Wallet.Net.Models.Budget
{
    public class BudgetChangeEntry
    {
        public DateTime? CreatedAt { get; set; }
        public decimal? Limit { get; set; }
        public string? Period { get; set; }

        /// <summary>
        /// How many periods this entry governs. Absent means open-ended (nothing after it takes over).
        /// </summary>
        public int? PeriodCount { get; set; }

        public string? PeriodStart { get; set; }
    }
}
