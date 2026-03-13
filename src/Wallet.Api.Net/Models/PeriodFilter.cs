using Wallet.Api.Net.Utility;

namespace Wallet.Api.Net.Models
{
    public class PeriodFilter
    {
        public PeriodPrefix Prefix { get; set; }
        public required int Value { get; set; }

        public override string ToString()
        {
            string prefixString = Prefix.ToCustomString();

            return $"{Value}{prefixString}";
        }
    }
}
