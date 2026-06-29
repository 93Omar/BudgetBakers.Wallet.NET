using System;
using BudgetBakers.Wallet.Net.Models.Delete;

namespace BudgetBakers.Wallet.Net.Utility
{
    internal static class DeletableEntityTypeExtensions
    {
        internal static string ToApiString(this DeletableEntityType value) => value switch
        {
            DeletableEntityType.Records => "records",
            DeletableEntityType.Budgets => "budgets",
            DeletableEntityType.StandingOrders => "standing-orders",
            DeletableEntityType.RecordRules => "record-rules",
            DeletableEntityType.Categories => "categories",
            DeletableEntityType.Accounts => "accounts",
            DeletableEntityType.Labels => "labels",
            _ => throw new InvalidOperationException($"Unsupported {nameof(DeletableEntityType)} value: {value}")
        };
    }
}
