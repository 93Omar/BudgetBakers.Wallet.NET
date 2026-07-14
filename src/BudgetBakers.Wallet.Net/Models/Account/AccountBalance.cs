namespace BudgetBakers.Wallet.Net.Models.Account
{
    /// <summary>
    /// Computed account balance with credit card / overdraft corrections applied.
    /// Read-only — populated by the API, not settable by the client.
    /// </summary>
    public class AccountBalance
    {
        public double? AvailableCredit { get; set; }
        public string? BalanceDisplayOption { get; set; }

        /// <summary>
        /// Formula variant used to compute the balance.
        /// One of: standard, creditCardManual, creditCardManualInverse,
        /// creditCardBank, creditCardBankReversed, overdraftManual, overdraftBank.
        /// </summary>
        public string? BalanceMode { get; set; }

        public string? BalanceModeFormula { get; set; }
        public double? CreditBalance { get; set; }
        public double? CreditLimit { get; set; }
        public string? CurrencyCode { get; set; }
        public double? CurrentBalance { get; set; }
        public string? Error { get; set; }
        public string? Formula { get; set; }
        public double? Initial { get; set; }
        public double? RawCurrentBalance { get; set; }
    }
}
