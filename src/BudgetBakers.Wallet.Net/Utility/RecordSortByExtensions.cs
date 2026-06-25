using System;
using BudgetBakers.Wallet.Net.Models.Record;

namespace BudgetBakers.Wallet.Net.Utility
{
    internal static class RecordSortByExtensions
    {
        internal static string ToApiString(this RecordSortBy value) => value switch
        {
            RecordSortBy.RecordDateAscending => "+recordDate",
            RecordSortBy.RecordDateDescending => "-recordDate",
            RecordSortBy.AmountAscending => "+amount",
            RecordSortBy.AmountDescending => "-amount",
            RecordSortBy.CreatedAtDescending => "-createdAt",
            RecordSortBy.UpdatedAtDescending => "-updatedAt",
            _ => throw new InvalidOperationException($"Unsupported {nameof(RecordSortBy)} value: {value}")
        };
    }
}
