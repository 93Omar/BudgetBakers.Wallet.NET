namespace BudgetBakers.Wallet.Net.Models.Record
{
    public class CreateRecordItem
    {
        public required string AccountId { get; set; }
        public required RecordAmount Amount { get; set; }
        public required DateTime RecordDate { get; set; }
        public required PaymentType PaymentType { get; set; }
        public string? CategoryId { get; set; }
        public string? CounterParty { get; set; }
        public string? Note { get; set; }
        public IList<string>? LabelIds { get; set; }
        public RecordState? RecordState { get; set; }
        public RecordPlaceInput? Place { get; set; }
    }
}
