using System;
using System.Globalization;
using BudgetBakers.Wallet.Net.Utility;

namespace BudgetBakers.Wallet.Net.Models
{
    public class DateFilter
    {
        public RangePrefix Prefix { get; set; }
        public DateTime Value { get; set; }

        public override string ToString()
        {
            return $"{Prefix.ToCustomString()}.{Value.ToString("o", CultureInfo.InvariantCulture)}";
        }
    }
}
