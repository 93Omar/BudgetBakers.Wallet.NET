namespace Wallet.Api.Net.Models.Pagination
{
    internal interface IPaginatedResponse
    {
        PaginationInfo Pagination { get; }
    }
}
