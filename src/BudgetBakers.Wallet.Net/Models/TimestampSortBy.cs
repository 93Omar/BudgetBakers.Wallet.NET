namespace BudgetBakers.Wallet.Net.Models
{
    /// <summary>
    /// Sort field for endpoints that support createdAt/updatedAt ordering.
    /// Use with +/- prefix convention via the extension method.
    /// </summary>
    public enum TimestampSortBy
    {
        CreatedAtAscending = 0,
        CreatedAtDescending = 1,
        UpdatedAtAscending = 2,
        UpdatedAtDescending = 3
    }
}
