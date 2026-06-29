namespace BudgetBakers.Wallet.Net.Models
{
    public class IdsOperation
    {
        public IList<string>? ReplaceWith { get; set; }
        public IList<string>? Add { get; set; }
        public IList<string>? Remove { get; set; }
    }
}
