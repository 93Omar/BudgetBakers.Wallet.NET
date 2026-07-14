namespace BudgetBakers.Wallet.Net.Models.Budget
{
    public class ExcludedBreakdown
    {
        public int? ArchivedAccounts { get; set; }
        public int? Debts { get; set; }
        public int? IncomeCategories { get; set; }
        public int? Total { get; set; }
        public double? TotalAmountSum { get; set; }
        public int? Transfers { get; set; }
        public int? UnknownCategories { get; set; }
    }
}
