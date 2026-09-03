namespace BudgetBakers.Wallet.Net.Models
{
    public class BatchOperationSummary
    {
        public int Total { get; set; }
        public int Succeeded { get; set; }
        public int ClientErrors { get; set; }
        public int ServerErrors { get; set; }

        /// <summary>
        /// Documents actually written or removed, counted from confirmed write outcomes and deduplicated. Not a
        /// copy of <see cref="Succeeded"/>.
        /// </summary>
        public int DocumentsWritten { get; set; }
    }
}
