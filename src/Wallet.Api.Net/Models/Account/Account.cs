using System;

namespace Wallet.Api.Net.Models.Account
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
        /// Hex color code.
        /// </summary>
        public string? Color { get; set; }

        public DateTime? CreatedAt { get; set; }
        public bool ExcludeFromStats { get; set; }

        /// <summary>
        /// Unique identifier.
        /// </summary>
        public Guid? Id { get; set; }

        /// <summary>
        /// Account balance before any recorded transaction activity, in the account's original currency.
        /// </summary>
        public Balance? InitialBalance { get; set; }

        /// <summary>
        /// initialBalance converted to the user's base currency, using the exchange rate at the time of account creation/update.
        /// </summary>
        public Balance? InitialBaseBalance { get; set; }

        public string? Name { get; set; }
        public RecordStats? RecordStats { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
