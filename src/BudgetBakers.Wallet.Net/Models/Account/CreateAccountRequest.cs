using BudgetBakers.Wallet.Net.Models;

namespace BudgetBakers.Wallet.Net.Models.Account
{
    public class CreateAccountRequest
    {
        public required string Name { get; set; }
        public required CreatableAccountType AccountType { get; set; }
        public required string CurrencyCode { get; set; }
        public required decimal InitialBalance { get; set; }
        public EntityColor? Color { get; set; }
        public string? BankAccountNumber { get; set; }
        public bool ExcludeFromStats { get; set; }
    }
}
