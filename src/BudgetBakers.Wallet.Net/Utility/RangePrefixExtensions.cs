using System;
using System.Collections.Generic;
using System.Text;
using BudgetBakers.Wallet.Net.Models;

namespace BudgetBakers.Wallet.Net.Utility
{
    internal static class RangePrefixExtensions
    {
        internal static string ToCustomString(this RangePrefix value)
        {
            string rangePrefix = value switch
            {
                RangePrefix.Equals => "eq",
                RangePrefix.GreaterThan => "gt",
                RangePrefix.GreaterThanOrEqual => "gte",
                RangePrefix.LessThan => "lt",
                RangePrefix.LessThanOrEqual => "lte",
                _ => throw new InvalidOperationException($"Unsupported {nameof(RangePrefix)} value: {value}")
            };

            return rangePrefix;
        }
    }
}
