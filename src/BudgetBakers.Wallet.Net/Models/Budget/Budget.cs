using System;
using System.Collections.Generic;

namespace BudgetBakers.Wallet.Net.Models.Budget
{
    public class Budget
    {
        public IList<string> AccountIds { get; set; } = [];
        public bool? Closed { get; set; }
        public string? ClosedDate { get; set; }
        public IList<string> CategoryIds { get; set; } = [];
        public DateTime? CreatedAt { get; set; }
        public string? CurrencyCode { get; set; }
        public string? EndDate { get; set; }
        public string? Id { get; set; }
        public decimal? Limit { get; set; }
        public IList<BudgetChangeEntry> LimitOverrides { get; set; } = [];
        public IList<string> LabelIds { get; set; } = [];
        public string? Name { get; set; }
        public IList<BudgetChangeEntry> PastLimitOverrides { get; set; } = [];
        public BudgetSpending? Spending { get; set; }
        public string? StartDate { get; set; }
        public string? Type { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
