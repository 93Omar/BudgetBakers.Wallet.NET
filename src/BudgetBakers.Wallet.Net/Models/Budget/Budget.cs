using System;
using System.Collections.Generic;

namespace BudgetBakers.Wallet.Net.Models.Budget
{
    public class Budget
    {
        public IList<Guid> AccountIds { get; set; } = Array.Empty<Guid>();
        public string? Amount { get; set; }
        public IList<Guid> CategoryIds { get; set; } = Array.Empty<Guid>();
        public DateTime? CreatedAt { get; set; }
        public string? CurrencyCode { get; set; }
        public string? EndDate { get; set; }
        public Guid? Id { get; set; }
        public IList<Guid> LabelIds { get; set; } = Array.Empty<Guid>();
        public string? Name { get; set; }
        public string? StartDate { get; set; }
        public string? Type { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
