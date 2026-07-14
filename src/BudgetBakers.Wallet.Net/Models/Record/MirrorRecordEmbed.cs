using BudgetBakers.Wallet.Net.Models;

namespace BudgetBakers.Wallet.Net.Models.Record
{
    public class MirrorRecordEmbed
    {
        public string? AccountId { get; set; }
        public AmountWithCurrency? Amount { get; set; }
        public string? CounterParty { get; set; }
        public string? Id { get; set; }
        public string? Note { get; set; }
    }
}
