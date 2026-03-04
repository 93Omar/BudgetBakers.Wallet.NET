using Microsoft.Extensions.Configuration;
using System;
using System.Threading;
using System.Threading.Tasks;
using Wallet.Api.Net.Services;

namespace ConsoleApp.Services
{
    public class UserSecretsAccessTokenProvider : IAccessTokenProvider
    {
        private readonly IConfiguration _configuration;
        private const string ConfigKey = "Wallet:AccessToken";

        public UserSecretsAccessTokenProvider(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public Task<string> GetAccessTokenAsync(CancellationToken ct = default)
        {
            string? token = _configuration[ConfigKey];

            if (string.IsNullOrWhiteSpace(token))
                throw new InvalidOperationException($"Access token not found in configuration (key: '{ConfigKey}').");

            return Task.FromResult(token);
        }
    }
}
