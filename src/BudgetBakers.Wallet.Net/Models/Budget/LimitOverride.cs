namespace BudgetBakers.Wallet.Net.Models.Budget
{
    public class LimitOverride
    {
        public required string Period { get; set; }
        public decimal? Limit { get; set; }
        public bool? SetBaseline { get; set; }
    }
}
