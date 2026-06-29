namespace BudgetBakers.Wallet.Net.Models.Budget
{
    public class UpdateBudgetResult
    {
        public string? Id { get; set; }
        public bool Success { get; set; }
        public Budget? Budget { get; set; }
        public string? Error { get; set; }
        public string? ErrorType { get; set; }
    }
}
