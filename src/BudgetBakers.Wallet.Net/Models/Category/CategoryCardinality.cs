namespace BudgetBakers.Wallet.Net.Models.Category
{
    /// <summary>
    /// A category's spending nature. A category with no cardinality of its own inherits its base category's value.
    /// </summary>
    public enum CategoryCardinality
    {
        None = 0,
        Must = 1,
        Need = 2,
        Want = 3
    }
}
