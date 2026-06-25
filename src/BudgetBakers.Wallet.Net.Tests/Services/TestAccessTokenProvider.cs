using BudgetBakers.Wallet.Net.Services;

namespace BudgetBakers.Wallet.Net.Tests.Services
{
    internal sealed class TestAccessTokenProvider : IAccessTokenProvider
    {
        private readonly string _accessToken;

        public TestAccessTokenProvider(string accessToken)
        {
            _accessToken = accessToken;
        }

        public CancellationToken LastCancellationToken { get; private set; }

        public Task<string> GetAccessTokenAsync(CancellationToken ct = default)
        {
            LastCancellationToken = ct;
            return Task.FromResult(_accessToken);
        }
    }
}
