namespace BudgetBakers.Wallet.Net.Models.Delete
{
    public class DeleteResult
    {
        public int InputIndex { get; set; }
        public string? Id { get; set; }
        public bool Success { get; set; }
        public string? Error { get; set; }
        public string? ErrorType { get; set; }

        /// <summary>
        /// Input field names the error is attributable to; empty for item-level errors.
        /// </summary>
        public IList<string> Fields { get; set; } = [];
    }
}
