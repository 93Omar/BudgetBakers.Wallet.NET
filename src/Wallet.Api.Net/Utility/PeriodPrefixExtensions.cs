using Wallet.Api.Net.Models;

namespace Wallet.Api.Net.Utility
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
                _ => throw new InvalidOperationException($"Unsupported PeriodPrefix value: {value}")
            };

            return periodPrefix;
        }
    }
}
