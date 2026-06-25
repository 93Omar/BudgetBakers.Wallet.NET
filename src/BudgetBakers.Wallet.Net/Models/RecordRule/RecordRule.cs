using System;
using System.Collections.Generic;

namespace BudgetBakers.Wallet.Net.Models.RecordRule
{
    public class RecordRule
    {
        public Category.Category? Category { get; set; }
        public DateTime? CreatedAt { get; set; }
        public Guid? FromAccountId { get; set; }
        public Guid? Id { get; set; }
        public IList<string> Keywords { get; set; } = Array.Empty<string>();
        public IList<Label.Label> Labels { get; set; } = Array.Empty<Label.Label>();
        public string? Name { get; set; }
        public Guid? ToAccountId { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
