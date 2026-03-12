namespace Wallet.Api.Net.Tests.TestInfrastructure
{
    internal readonly struct NullToStringValue
    {
        public override string ToString()
            => null!;
    }
}
