namespace BudgetBakers.Wallet.Net.Models.Label
{
    public class UpdateLabelResult
    {
        public string? Id { get; set; }
        public bool Success { get; set; }
        public Label? Label { get; set; }
        public string? Error { get; set; }
        public string? ErrorType { get; set; }
    }
}
