using System;
using System.Collections.Generic;
using CategoryModel = BudgetBakers.Wallet.Net.Models.Category.Category;
using LabelModel = BudgetBakers.Wallet.Net.Models.Label.Label;

namespace BudgetBakers.Wallet.Net.Models.Record
{
    public class Record
    {
        public string? AccountId { get; set; }
        public bool? AccountIsBankSync { get; set; }
        public string? AccountName { get; set; }
        public Balance? Amount { get; set; }
        public CategoryModel? Category { get; set; }
        public ConvertedAmount? ConvertedAmount { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? Id { get; set; }
        public IList<LabelModel>? Labels { get; set; } = [];
        public string? Note { get; set; }
        public string? CounterParty { get; set; }
        public IList<RecordPhoto> Photos { get; set; } = [];
        public RecordPlace? Place { get; set; }
        public DateTime? RecordDate { get; set; }
        public RecordState? RecordState { get; set; }
        public RecordType? RecordType { get; set; }
        public string? Source { get; set; }
        public TransferOutput? Transfer { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
