namespace BudgetBakers.Wallet.Net.Models.Record
{
    public class UpdateRecordResult
    {
        public string? Id { get; set; }
        public bool Success { get; set; }
        public Record? Record { get; set; }
        public string? Error { get; set; }
        public string? ErrorType { get; set; }
    }
}
