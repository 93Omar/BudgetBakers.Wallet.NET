using System;
using System.Collections.Generic;
using Wallet.Api.Net.Models.Category;
using Wallet.Api.Net.Models.Label;

namespace Wallet.Api.Net.Models.Record
{
    public class Record
    {
        public string? AccountId { get; set; }
        public Balance? Amount { get; set; }
        public Balance? BaseAmount { get; set; }
        public Wallet.Api.Net.Models.Category.Category? Category { get; set; }
        public DateTime? CreatedAt { get; set; }
        public Guid? Id { get; set; }
        public IList<Wallet.Api.Net.Models.Label.Label>? Labels { get; set; } = Array.Empty<Wallet.Api.Net.Models.Label.Label>();
        public string? Note { get; set; }
        public string? Payee { get; set; }
        public string? Payer { get; set; }
        public string? PaymentType { get; set; }
        public IList<RecordPhoto> Photos { get; set; } = Array.Empty<RecordPhoto>();
        public RecordPlace? Place { get; set; }
        public DateTime? RecordDate { get; set; }
        public string? RecordState { get; set; }
        public string? RecordType { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
    
}
