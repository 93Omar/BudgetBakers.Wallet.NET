namespace BudgetBakers.Wallet.Net.Models.Pagination
{
    internal interface IPaginatedResponse
    {
        PaginationInfo Pagination { get; }
    }
}
