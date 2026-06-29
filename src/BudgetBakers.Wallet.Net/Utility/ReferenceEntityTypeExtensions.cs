using System;
using BudgetBakers.Wallet.Net.Models.References;

namespace BudgetBakers.Wallet.Net.Utility
{
    internal static class ReferenceEntityTypeExtensions
    {
        internal static string ToApiString(this ReferenceEntityType value) => value switch
        {
            ReferenceEntityType.Categories => "categories",
            ReferenceEntityType.Records => "records",
            ReferenceEntityType.Accounts => "accounts",
            ReferenceEntityType.Labels => "labels",
            _ => throw new InvalidOperationException($"Unsupported {nameof(ReferenceEntityType)} value: {value}")
        };
    }
}
