using System;
using System.Collections.Generic;

namespace BudgetBakers.Wallet.Net.Models.RecordRule
{
    public class RecordRule
    {
        public Category.Category? Category { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? FromAccountId { get; set; }
        public string? Id { get; set; }
        public IList<string> Keywords { get; set; } = [];
        public IList<Label.Label> Labels { get; set; } = [];
        public string? Name { get; set; }
        public string? ToAccountId { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
