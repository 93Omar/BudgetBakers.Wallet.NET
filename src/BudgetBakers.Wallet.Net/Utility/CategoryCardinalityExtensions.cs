using System;
using BudgetBakers.Wallet.Net.Models.Category;

namespace BudgetBakers.Wallet.Net.Utility
{
    internal static class CategoryCardinalityExtensions
    {
        internal static string ToApiString(this CategoryCardinality value) => value switch
        {
            CategoryCardinality.None => "none",
            CategoryCardinality.Must => "must",
            CategoryCardinality.Need => "need",
            CategoryCardinality.Want => "want",
            _ => throw new InvalidOperationException($"Unsupported {nameof(CategoryCardinality)} value: {value}")
        };
    }
}
