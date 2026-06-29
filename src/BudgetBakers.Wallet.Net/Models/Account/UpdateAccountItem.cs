using BudgetBakers.Wallet.Net.Models;

namespace BudgetBakers.Wallet.Net.Models.Account
{
    public class UpdateAccountItem
    {
        public required string Id { get; set; }
        public string? Name { get; set; }
        public EntityColor? Color { get; set; }
        public bool? Archived { get; set; }
        public bool? ExcludeFromStats { get; set; }
        public double? InitialBalance { get; set; }
        public string? BankAccountNumber { get; set; }
    }
}
