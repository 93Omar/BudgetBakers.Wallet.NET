using System;
using BudgetBakers.Wallet.Net.Models.Category;

namespace BudgetBakers.Wallet.Net.Utility
{
    internal static class CategoryResetFieldExtensions
    {
        internal static string ToApiString(this CategoryResetField value) => value switch
        {
            CategoryResetField.Name => "name",
            CategoryResetField.Cardinality => "cardinality",
            CategoryResetField.Color => "color",
            _ => throw new InvalidOperationException($"Unsupported {nameof(CategoryResetField)} value: {value}")
        };
    }
}
