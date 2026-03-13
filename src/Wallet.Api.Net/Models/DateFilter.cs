using System;
using System.Collections.Generic;
using System.Text;
using Wallet.Api.Net.Utility;

namespace Wallet.Api.Net.Models
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
