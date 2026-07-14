using System;
using BudgetBakers.Wallet.Net.Models.Budget;

namespace BudgetBakers.Wallet.Net.Utility
{
    internal static class BudgetSpendingDepthExtensions
    {
        internal static string ToApiString(this BudgetSpendingDepth value) => value switch
        {
            BudgetSpendingDepth.None => "none",
            BudgetSpendingDepth.Current => "current",
            BudgetSpendingDepth.CurrentPlus2 => "current+2",
            BudgetSpendingDepth.CurrentPlus5 => "current+5",
            BudgetSpendingDepth.CurrentPlus10 => "current+10",
            BudgetSpendingDepth.CurrentPlus25 => "current+25",
            _ => throw new InvalidOperationException($"Unsupported {nameof(BudgetSpendingDepth)} value: {value}")
        };
    }
}
