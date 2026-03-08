using System;

namespace Wallet.Api.Net.Models.Account
{
    public class Account
    {
        public AccountType? AccountType { get; set; }

        public bool Archived { get; set; }

        public string? BankAccountNumber { get; set; }

        public string? Color { get; set; }

        public DateTime? CreatedAt { get; set; }

        public bool ExcludeFromStats { get; set; }

        public Guid? Id { get; set; }

        public Balance? InitialBalance { get; set; }

        public Balance? InitialBaseBalance { get; set; }

        public string? Name { get; set; }

        public RecordStats? RecordStats { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
