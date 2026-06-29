using System;
using System.Net.Http;
using BudgetBakers.Wallet.Net.Services;
using Microsoft.Extensions.Logging.Abstractions;

namespace BudgetBakers.Wallet.Net.Utility
{
    public static class WalletClientFactory
    {
        public static HttpClient CreateHttpClient(IAccessTokenProvider tokenProvider, Action<HttpClient> configureClient)
        {
            HttpMessageHandler inner = new LoggingDelegatingHandler(NullLogger<LoggingDelegatingHandler>.Instance)
            {
                InnerHandler = new HttpClientHandler()
            };

            BearerTokenDelegatingHandler handler = new BearerTokenDelegatingHandler(tokenProvider)
            {
                InnerHandler = inner
            };

            HttpClient client = new HttpClient(handler);
            configureClient(client);

            return client;
        }
    }
}
