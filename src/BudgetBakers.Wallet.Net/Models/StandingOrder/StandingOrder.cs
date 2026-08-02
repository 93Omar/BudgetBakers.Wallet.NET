using System;
using System.Collections.Generic;

namespace BudgetBakers.Wallet.Net.Models.StandingOrder
{
    public class StandingOrder
    {
        public string? AccountId { get; set; }
        public double? Amount { get; set; }
        public string? CategoryId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? CurrencyCode { get; set; }
        public DateTime? DueDate { get; set; }
        public bool DueDateNotificationEnabled { get; set; }
        public string? GenerateFromDate { get; set; }
        public string? Id { get; set; }
        public IList<BudgetBakers.Wallet.Net.Models.Label.Label> Labels { get; set; } = [];
        public bool ManualPayment { get; set; }
        public string? Name { get; set; }
        public string? Note { get; set; }
        public string? CounterParty { get; set; }
        public string? Reminder { get; set; }
        public string? RecurrenceRule { get; set; }
        public bool ThreeDaysBeforeNotificationEnabled { get; set; }
        public StandingOrderType? Type { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
