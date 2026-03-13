using System;
using System.Collections.Generic;
using System.Text;

namespace Wallet.Api.Net.Models
{
    public enum RangePrefix
    {
        Equals = 0,
        GreaterThan = 1,
        LessThan = 2,
        GreaterThanOrEqual = 3,
        LessThanOrEqual = 4
    }
}
