using System.Collections.Generic;

namespace BudgetBakers.Wallet.Net.Models.Budget
{
    public class BudgetPeriodSpending
    {
        public IList<string> ConvertedCurrencies { get; set; } = [];
        public string? Error { get; set; }
        public ExcludedBreakdown? Excluded { get; set; }

        /// <summary>
        /// The limit in force for this period (baseline limit or an applicable override). Read-only.
        /// </summary>
        public decimal? EffectiveLimit { get; set; }

        public bool? Incomplete { get; set; }
        public decimal? Limit { get; set; }
        public decimal? Overspent { get; set; }
        public string? Period { get; set; }
        public string? PeriodEnd { get; set; }
        public string? PeriodStart { get; set; }
        public double? Progress { get; set; }
        public int? RecordCount { get; set; }
        public decimal? Remaining { get; set; }
        public decimal? Spent { get; set; }
        public decimal? TotalExpenses { get; set; }
        public decimal? TotalIncomes { get; set; }
    }
}
