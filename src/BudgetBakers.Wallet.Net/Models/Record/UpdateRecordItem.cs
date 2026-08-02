namespace BudgetBakers.Wallet.Net.Models.Record
{
    public class UpdateRecordItem
    {
        public required string Id { get; set; }
        public string? AccountId { get; set; }
        public RecordAmount? Amount { get; set; }
        public DateTime? RecordDate { get; set; }
        public RecordState? RecordState { get; set; }
        public string? CategoryId { get; set; }
        public string? CounterParty { get; set; }
        public string? Note { get; set; }
        public IdsOperation? LabelIds { get; set; }
        public IList<RecordClearField>? Clear { get; set; }
        public RecordPlaceInput? Place { get; set; }
    }
}
