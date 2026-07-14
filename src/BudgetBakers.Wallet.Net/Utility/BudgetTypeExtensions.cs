using System;
using BudgetBakers.Wallet.Net.Models.Budget;

namespace BudgetBakers.Wallet.Net.Utility
{
    internal static class BudgetTypeExtensions
    {
        internal static string ToApiString(this BudgetType value) => value switch
        {
            BudgetType.BudgetIntervalWeek => "BUDGET_INTERVAL_WEEK",
            BudgetType.BudgetIntervalMonth => "BUDGET_INTERVAL_MONTH",
            BudgetType.BudgetIntervalYear => "BUDGET_INTERVAL_YEAR",
            BudgetType.BudgetAll => "BUDGET_ALL",
            BudgetType.BudgetCustom => "BUDGET_CUSTOM",
            _ => throw new InvalidOperationException($"Unsupported {nameof(BudgetType)} value: {value}")
        };
    }
}
