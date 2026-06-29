namespace BudgetBakers.Wallet.Net.Models
{
    public class BatchOperationSummary
    {
        public int Total { get; set; }
        public int Succeeded { get; set; }
        public int ClientErrors { get; set; }
        public int ServerErrors { get; set; }
    }
}
