using System;

namespace BudgetBakers.Wallet.Net.Models.Budget
{
    public class BudgetChangeEntry
    {
        public DateTime? CreatedAt { get; set; }
        public double? Limit { get; set; }
        public string? Period { get; set; }
        public string? PeriodStart { get; set; }
    }
}
