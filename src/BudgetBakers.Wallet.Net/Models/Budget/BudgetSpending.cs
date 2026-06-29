using System;
using System.Collections.Generic;

namespace BudgetBakers.Wallet.Net.Models.Budget
{
    public class BudgetSpending
    {
        public DateTime? ComputedAt { get; set; }
        public BudgetPeriodSpending? Current { get; set; }
        public IList<BudgetPeriodSpending> Past { get; set; } = [];
    }
}
