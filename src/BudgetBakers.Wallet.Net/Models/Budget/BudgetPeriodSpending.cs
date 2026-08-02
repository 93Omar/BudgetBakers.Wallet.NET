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
        public double? EffectiveLimit { get; set; }

        public bool? Incomplete { get; set; }
        public double? Limit { get; set; }
        public double? Overspent { get; set; }
        public string? Period { get; set; }
        public string? PeriodEnd { get; set; }
        public string? PeriodStart { get; set; }
        public double? Progress { get; set; }
        public int? RecordCount { get; set; }
        public double? Remaining { get; set; }
        public double? Spent { get; set; }
        public double? TotalExpenses { get; set; }
        public double? TotalIncomes { get; set; }
    }
}
