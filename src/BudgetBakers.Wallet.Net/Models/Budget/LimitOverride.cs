namespace BudgetBakers.Wallet.Net.Models.Budget
{
    public class LimitOverride
    {
        public required string Period { get; set; }
        public double? Limit { get; set; }
        public bool? SetBaseline { get; set; }
    }
}
