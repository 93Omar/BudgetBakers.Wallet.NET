using System;
using BudgetBakers.Wallet.Net.Models.Record;

namespace BudgetBakers.Wallet.Net.Utility
{
    internal static class RecordTypeExtensions
    {
        internal static string ToApiString(this RecordType value) => value switch
        {
            RecordType.Income => "income",
            RecordType.Expense => "expense",
            _ => throw new InvalidOperationException($"Unsupported {nameof(RecordType)} value: {value}")
        };
    }
}
