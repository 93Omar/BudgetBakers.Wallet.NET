using ConsoleApp.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Threading;
using System.Threading.Tasks;
using Wallet.Api.Net.Services;

namespace ConsoleApp.Services
{
    public class OptionsAccessTokenProvider : IAccessTokenProvider
    {
        private readonly WalletOptions _walletOptions;

        public OptionsAccessTokenProvider(IOptions<WalletOptions> walletOptions)
        {
            _walletOptions = walletOptions?.Value ?? throw new ArgumentNullException(nameof(walletOptions));
        }

        public Task<string> GetAccessTokenAsync(CancellationToken ct = default)
        {
            if (string.IsNullOrWhiteSpace(_walletOptions.AccessToken))
                throw new InvalidOperationException($"Access token not found in configuration section '{WalletOptions.SectionName}' (property: '{nameof(WalletOptions.AccessToken)}').");

            return Task.FromResult(_walletOptions.AccessToken);
        }
    }
}
