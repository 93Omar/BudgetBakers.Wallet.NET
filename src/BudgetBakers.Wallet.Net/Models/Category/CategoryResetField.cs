namespace BudgetBakers.Wallet.Net.Models.Category
{
    /// <summary>
    /// A category field that can be restored to its base (system) category default. Base categories only —
    /// custom subcategories have no defaults.
    /// </summary>
    public enum CategoryResetField
    {
        Name = 0,
        Cardinality = 1,
        Color = 2
    }
}
