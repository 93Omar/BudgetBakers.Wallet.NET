using System;
using System.Collections.Generic;
using System.Text;
using BudgetBakers.Wallet.Net.Utility;

namespace BudgetBakers.Wallet.Net.Models
{
    public class DateFilter
    {
        public RangePrefix Prefix { get; set; }
        public DateTime Value { get; set; }

        public override string ToString()
        {
            string prefixString = Prefix.ToCustomString();

            return $"{prefixString}.{Value}";
        }
    }
}
