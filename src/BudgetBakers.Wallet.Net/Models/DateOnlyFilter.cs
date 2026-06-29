using System;
using System.Globalization;
using BudgetBakers.Wallet.Net.Utility;

namespace BudgetBakers.Wallet.Net.Models
{
    public class DateOnlyFilter
    {
        public RangePrefix Prefix { get; set; }
        public DateOnly Value { get; set; }

        public override string ToString()
            => $"{Prefix.ToCustomString()}.{Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)}";
    }
}
