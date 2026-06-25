using System;
using BudgetBakers.Wallet.Net.Models;

namespace BudgetBakers.Wallet.Net.Models.Goal
{
    public class Goal
    {
        public string? Color { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? DesiredDate { get; set; }
        public string? IconName { get; set; }
        public Guid? Id { get; set; }
        public AmountWithCurrency? InitialAmount { get; set; }
        public string? Name { get; set; }
        public string? Note { get; set; }
        public string? State { get; set; }
        public string? StateUpdatedAt { get; set; }
        public AmountWithCurrency? TargetAmount { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
