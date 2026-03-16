using System;
using System.Collections.Generic;
using System.Text;
using Wallet.Api.Net.Models;

namespace Wallet.Api.Net.Utility
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
