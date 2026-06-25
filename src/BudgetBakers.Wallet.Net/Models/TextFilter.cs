using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using BudgetBakers.Wallet.Net.Utility;

namespace BudgetBakers.Wallet.Net.Models
{
    public class TextFilter
    {
        public TextPrefix Prefix { get; set; }
        public required string Value { get; set; } = null!;

        public override string ToString()
        {
            string prefixString = Prefix.ToCustomString();

            return $"{prefixString}.{Value}";
        }
    }
}
