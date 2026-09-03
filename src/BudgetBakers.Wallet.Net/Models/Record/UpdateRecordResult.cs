namespace BudgetBakers.Wallet.Net.Models.Record
{
    public class UpdateRecordResult
    {
        public int InputIndex { get; set; }
        public string? Id { get; set; }
        public bool Success { get; set; }
        public Record? Record { get; set; }
        public string? Error { get; set; }
        public string? ErrorType { get; set; }

        /// <summary>
        /// Input field names the error is attributable to; empty when the error belongs to the item as a whole.
        /// </summary>
        public IList<string> Fields { get; set; } = [];
    }
}
