using System;
using System.Collections.Generic;

namespace BudgetBakers.Wallet.Net.Models.StandingOrder
{
    public class StandingOrderItem
    {
        public string? Id { get; set; }
        public string? StandingOrderId { get; set; }
        public DateTime? OriginalDate { get; set; }
        public DateTime? AlignedDate { get; set; }
        public bool Dismissed { get; set; }
        public DateTime? PaidDate { get; set; }
        public DateTime? PaidFromAppDate { get; set; }
        public IList<string> RecordIds { get; set; } = [];
    }
}
