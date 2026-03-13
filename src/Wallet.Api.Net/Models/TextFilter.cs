using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using Wallet.Api.Net.Utility;

namespace Wallet.Api.Net.Models
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
