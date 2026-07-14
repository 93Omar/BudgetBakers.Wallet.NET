namespace BudgetBakers.Wallet.Net.Models.Delete
{
    public class DeleteResult
    {
        public string? Id { get; set; }
        public bool Success { get; set; }
        public string? Error { get; set; }
        public string? ErrorType { get; set; }
    }
}
