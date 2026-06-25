using System;
using System.Collections.Generic;
using BudgetBakers.Wallet.Net.Models.Category;
using BudgetBakers.Wallet.Net.Models.Label;

namespace BudgetBakers.Wallet.Net.Models.Record
{
    public class Record
    {
        public string? AccountId { get; set; }

        /// <summary>
        /// Transaction amount in its original currency (before conversion). May differ from baseAmount for foreign currency transactions.
        /// </summary>
        public Balance? Amount { get; set; }

        /// <summary>
        /// Transaction amount converted to the account's base currency. Use this for calculations and filtering.
        /// </summary>
        public Balance? BaseAmount { get; set; }

        /// <summary>
        /// Full category data embedded in response.
        /// </summary>
        public BudgetBakers.Wallet.Net.Models.Category.Category? Category { get; set; }

        public DateTime? CreatedAt { get; set; }

        /// <summary>
        /// Unique identifier.
        /// </summary>
        public Guid? Id { get; set; }

        /// <summary>
        /// Labels attached to this record.
        /// </summary>
        public IList<BudgetBakers.Wallet.Net.Models.Label.Label>? Labels { get; set; } = Array.Empty<BudgetBakers.Wallet.Net.Models.Label.Label>();

        public string? Note { get; set; }

        /// <summary>
        /// Payee name (for expense records).
        /// </summary>
        public string? Payee { get; set; }

        /// <summary>
        /// Payer name (for income records).
        /// </summary>
        public string? Payer { get; set; }

        /// <summary>
        /// Payment method.
        /// </summary>
        public PaymentType? PaymentType { get; set; }

        /// <summary>
        /// Photos attached to this record.
        /// </summary>
        public IList<RecordPhoto> Photos { get; set; } = Array.Empty<RecordPhoto>();

        public RecordPlace? Place { get; set; }

        /// <summary>
        /// Date of the transaction.
        /// </summary>
        public DateTime? RecordDate { get; set; }

        /// <summary>
        /// Transaction state.
        /// </summary>
        public RecordState? RecordState { get; set; }

        /// <summary>
        /// Transaction type.
        /// </summary>
        public RecordType? RecordType { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
    
}
