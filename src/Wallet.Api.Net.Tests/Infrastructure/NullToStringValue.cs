namespace Wallet.Api.Net.Tests.Infrastructure
{
    internal readonly struct NullToStringValue
    {
        public override string ToString()
            => null!;
    }
}
