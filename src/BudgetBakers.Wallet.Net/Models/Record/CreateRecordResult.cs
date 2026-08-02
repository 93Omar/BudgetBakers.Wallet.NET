namespace BudgetBakers.Wallet.Net.Models.Record
{
    public class CreateRecordResult
    {
        public int InputIndex { get; set; }
        public string? Id { get; set; }
        public bool Success { get; set; }
        public Record? Record { get; set; }
        public string? Error { get; set; }
        public string? ErrorType { get; set; }

        /// <summary>
        /// The auto-created B-side of a paired transfer, nested under the item that requested it. Null when the
        /// item is not a paired transfer, or when mirror creation failed.
        /// </summary>
        public CreateRecordMirrorResult? Mirror { get; set; }
    }
}
