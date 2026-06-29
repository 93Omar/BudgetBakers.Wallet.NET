namespace BudgetBakers.Wallet.Net.Models.Budget
{
    public class UpdateBudgetItem
    {
        public required string Id { get; set; }
        public string? Name { get; set; }
        public bool? Closed { get; set; }
        public string? StartDate { get; set; }
        public string? EndDate { get; set; }
        public IdsOperation? AccountIds { get; set; }
        public IdsOperation? CategoryIds { get; set; }
        public IdsOperation? LabelIds { get; set; }
        public double? ResetLimit { get; set; }
        public IList<LimitOverride>? LimitOverrides { get; set; }
    }
}
