using System;
using BudgetBakers.Wallet.Net.Models.Account;

namespace BudgetBakers.Wallet.Net.Utility
{
    internal static class CreatableAccountTypeExtensions
    {
        internal static string ToApiString(this CreatableAccountType value) => value switch
        {
            CreatableAccountType.General => "General",
            CreatableAccountType.Cash => "Cash",
            CreatableAccountType.CurrentAccount => "CurrentAccount",
            CreatableAccountType.SavingAccount => "SavingAccount",
            CreatableAccountType.Insurance => "Insurance",
            _ => throw new InvalidOperationException($"Unsupported {nameof(CreatableAccountType)} value: {value}")
        };
    }
}
