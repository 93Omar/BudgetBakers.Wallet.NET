namespace BudgetBakers.Wallet.Net.Models.Pagination
{
    public class PaginationInfo
    {
        /// <summary>
        /// Number of items per page (applied limit).
        /// </summary>
        public int Limit { get; set; }

        /// <summary>
        /// Starting position (applied offset).
        /// </summary>
        public int Offset { get; set; }

        /// <summary>
        /// Offset for next page (only present if more pages exist).
        /// </summary>
        public int NextOffset { get; set; }
    }
}
