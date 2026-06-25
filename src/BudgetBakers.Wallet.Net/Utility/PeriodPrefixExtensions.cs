using BudgetBakers.Wallet.Net.Models;

namespace BudgetBakers.Wallet.Net.Utility
{
    internal static class PeriodPrefixExtensions
    {
        internal static string ToCustomString(this PeriodPrefix value)
        {
            string periodPrefix = value switch
            {
                PeriodPrefix.Days => "days",
                PeriodPrefix.Weeks => "weeks",
                PeriodPrefix.Months => "months",
                _ => throw new InvalidOperationException($"Unsupported {nameof(PeriodPrefix)} value: {value}")
            };

            return periodPrefix;
        }
    }
}
