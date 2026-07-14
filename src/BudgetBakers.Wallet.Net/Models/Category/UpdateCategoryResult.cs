namespace BudgetBakers.Wallet.Net.Models.Category
{
    public class UpdateCategoryResult
    {
        public string? Id { get; set; }
        public bool Success { get; set; }
        public Category? Category { get; set; }
        public string? Error { get; set; }
        public string? ErrorType { get; set; }
    }
}
