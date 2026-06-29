using System;

namespace BudgetBakers.Wallet.Net.Models.Account
{
    public class Account
    {
        /// <summary>
        /// Account type: General (general purpose), Cash (physical cash), CurrentAccount (checking/current), CreditCard (credit card), SavingAccount (savings), Bonus (rewards), Insurance (policy), Investment (brokerage), Loan (liability), Mortgage (liability), Overdraft (facility).
        /// </summary>
        public AccountType? AccountType { get; set; }

        public bool Archived { get; set; }
        public string? BankAccountNumber { get; set; }

        /// <summary>
        /// Computed account balance with credit card / overdraft corrections. Read-only.
        /// </summary>
        public AccountBalance? Balance { get; set; }

        /// <summary>
        /// Hex color code.
        /// </summary>
        public string? Color { get; set; }

        public DateTime? CreatedAt { get; set; }
        public bool ExcludeFromStats { get; set; }

        /// <summary>
        /// Unique identifier.
        /// </summary>
        public string? Id { get; set; }

        /// <summary>
        /// Account balance before any recorded transaction activity, in the account's original currency.
        /// </summary>
        public Balance? InitialBalance { get; set; }

        /// <summary>
        /// Whether this account is connected to a bank via automatic sync. Read-only.
        /// </summary>
        public bool IsBankSync { get; set; }

        /// <summary>
        /// Whether this account contains investment portfolio data. Read-only.
        /// </summary>
        public bool IsInvestmentAccount { get; set; }

        public string? Name { get; set; }
        public RecordStats? RecordStats { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
