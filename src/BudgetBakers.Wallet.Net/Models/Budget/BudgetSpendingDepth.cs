namespace BudgetBakers.Wallet.Net.Models.Budget
{
    /// <summary>
    /// Controls how much spending data is included in each budget.
    /// </summary>
    public enum BudgetSpendingDepth
    {
        None = 0,
        Current = 1,
        CurrentPlus2 = 2,
        CurrentPlus5 = 3,
        CurrentPlus10 = 4,
        CurrentPlus25 = 5
    }
}
