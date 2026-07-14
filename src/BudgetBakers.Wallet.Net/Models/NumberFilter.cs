using System.Globalization;
using BudgetBakers.Wallet.Net.Utility;

namespace BudgetBakers.Wallet.Net.Models
{
    public class NumberFilter
    {
        public RangePrefix Prefix { get; set; }
        public double Value { get; set; }

        public override string ToString()
        {
            return $"{Prefix.ToCustomString()}.{Value.ToString(CultureInfo.InvariantCulture)}";
        }
    }
}
