using System;
using System.Collections.Generic;
using System.Text;

namespace Wallet.Api.Net.Models.Account
{
    public enum AccountType
    {
        General = 0,
        Cash = 1,
        CurrentAccount = 2,
        CreditCard = 3,
        SavinAccount = 4,
        Bonus = 5,
        Insurance = 6,
        Investment = 7,
        Loan = 8,
        Mortgage = 9,
        Overdraft = 10
    }
}
