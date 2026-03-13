using System;
using System.Net.Http;
using Wallet.Api.Net.Services;

namespace Wallet.Api.Net.Utility
{
    public static class WalletClientFactory
    {
        public static HttpClient CreateHttpClient(IAccessTokenProvider tokenProvider, Action<HttpClient> configureClient)
        {
            BearerTokenDelegatingHandler handler = new BearerTokenDelegatingHandler(tokenProvider)
            {
                InnerHandler = new HttpClientHandler()
            };

            HttpClient client = new HttpClient(handler);
            configureClient(client);

            return client;
        }
    }
}
