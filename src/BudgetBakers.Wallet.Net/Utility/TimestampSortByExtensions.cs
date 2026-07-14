using System;
using BudgetBakers.Wallet.Net.Models;

namespace BudgetBakers.Wallet.Net.Utility
{
    internal static class TimestampSortByExtensions
    {
        internal static string ToApiString(this TimestampSortBy value) => value switch
        {
            TimestampSortBy.CreatedAtAscending => "+createdAt",
            TimestampSortBy.CreatedAtDescending => "-createdAt",
            TimestampSortBy.UpdatedAtAscending => "+updatedAt",
            TimestampSortBy.UpdatedAtDescending => "-updatedAt",
            _ => throw new InvalidOperationException($"Unsupported {nameof(TimestampSortBy)} value: {value}")
        };
    }
}
