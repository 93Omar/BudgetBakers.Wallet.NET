namespace BudgetBakers.Wallet.Net.Models.Label
{
    public class UpdateLabelResult
    {
        public int InputIndex { get; set; }
        public string? Id { get; set; }
        public bool Success { get; set; }
        public Label? Label { get; set; }
        public string? Error { get; set; }
        public string? ErrorType { get; set; }

        /// <summary>
        /// Input field names the error is attributable to; empty when the error belongs to the item as a whole.
        /// </summary>
        public IList<string> Fields { get; set; } = [];
    }
}
