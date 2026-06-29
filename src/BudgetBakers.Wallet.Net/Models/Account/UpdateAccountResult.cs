namespace BudgetBakers.Wallet.Net.Models.Account
{
    public class UpdateAccountResult
    {
        public string? Id { get; set; }
        public bool Success { get; set; }
        public Account? Account { get; set; }
        public string? Error { get; set; }
        public string? ErrorType { get; set; }
    }
}
