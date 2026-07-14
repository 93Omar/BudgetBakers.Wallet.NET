using System;
using System.Collections.Generic;

namespace BudgetBakers.Wallet.Net.Models.Budget
{
    public class CreateBudgetRequest
    {
        public required string Name { get; set; }
        public required string CurrencyCode { get; set; }
        public required BudgetType Type { get; set; }
        public required double Limit { get; set; }
        public IList<string>? AccountIds { get; set; }
        public IList<string>? CategoryIds { get; set; }
        public IList<string>? LabelIds { get; set; }
        public DateOnly? StartDate { get; set; }
        public DateOnly? EndDate { get; set; }
    }
}
