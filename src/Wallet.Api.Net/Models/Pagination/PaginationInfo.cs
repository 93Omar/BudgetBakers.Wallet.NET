namespace Wallet.Api.Net.Models.Pagination
{
    public class PaginationInfo
    {
        public int Limit { get; set; }
        public int Offset { get; set; }
        public int NextOffset { get; set; }
    }
}
