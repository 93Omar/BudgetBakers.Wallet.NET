using System;
using System.Collections.Generic;
using System.Text;
using Wallet.Api.Net.Models;

namespace Wallet.Api.Net.Utility
{
    internal static class TextPrefixExtensions
    {
        internal static string ToCustomString(this TextPrefix value)
        {
            string textPrefix = value switch
            {
                TextPrefix.Equals => "eq",
                TextPrefix.Contains => "contains",
                TextPrefix.ContainsIgnoreCase => "contains-i",
                _ => throw new InvalidOperationException($"Unsupported TextPrefix value: {value}")
            };

            return textPrefix;
        }
    }
}
