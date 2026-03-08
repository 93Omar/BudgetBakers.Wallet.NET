using System;
using System.Collections.Generic;

namespace Wallet.Api.Net.Models.StandingOrder
{
    public class StandingOrder
    {
        public string? AccountId { get; set; }
        public string? Amount { get; set; }
        public Guid? CategoryId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? CurrencyCode { get; set; }
        public string? GenerateFromDate { get; set; }
        public Guid? Id { get; set; }
        public IList<Wallet.Api.Net.Models.Label.Label> Labels { get; set; } = Array.Empty<Wallet.Api.Net.Models.Label.Label>();
        public bool ManualPayment { get; set; }
        public string? Name { get; set; }
        public string? Note { get; set; }
        public string? Payee { get; set; }
        public string? Payer { get; set; }
        public string? PaymentType { get; set; }
        public string? RecurrenceRule { get; set; }
        public string? Type { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
