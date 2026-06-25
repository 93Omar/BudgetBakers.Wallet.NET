using System.Net;
using BudgetBakers.Wallet.Net.Services;
using BudgetBakers.Wallet.Net.Tests.Infrastructure;

namespace BudgetBakers.Wallet.Net.Tests.Services
{
    public class BearerTokenDelegatingHandlerTests
    {
        [Test]
        public async Task SendAsync_WhenTokenProviderReturnsToken_SetsBearerAuthorizationHeader()
        {
            var tokenProvider = new TestAccessTokenProvider("token-123");
            HttpRequestMessage? lastRequest = null;

            var innerHandler = new DelegateHttpMessageHandler((request, _) =>
            {
                lastRequest = request;
                return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent("{}")
                });
            });

            var handler = new BearerTokenDelegatingHandler(tokenProvider)
            {
                InnerHandler = innerHandler
            };

            using var invoker = new HttpMessageInvoker(handler);
            using var request = new HttpRequestMessage(HttpMethod.Get, "https://localhost/test");

            HttpResponseMessage response = await invoker.SendAsync(request, CancellationToken.None);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(lastRequest, Is.Not.Null);
                Assert.That(lastRequest!.Headers.Authorization, Is.Not.Null);
                Assert.That(lastRequest.Headers.Authorization!.Scheme, Is.EqualTo("Bearer"));
                Assert.That(lastRequest.Headers.Authorization.Parameter, Is.EqualTo("token-123"));
            }
        }

        [Test]
        public async Task SendAsync_WhenCancellationTokenProvided_PassesTokenToProviderAndInnerHandler()
        {
            var tokenProvider = new TestAccessTokenProvider("token-123");
            CancellationToken lastInnerCancellationToken = default;

            var innerHandler = new DelegateHttpMessageHandler((_, cancellationToken) =>
            {
                lastInnerCancellationToken = cancellationToken;
                return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent("{}")
                });
            });

            var handler = new BearerTokenDelegatingHandler(tokenProvider)
            {
                InnerHandler = innerHandler
            };

            using var invoker = new HttpMessageInvoker(handler);
            using var request = new HttpRequestMessage(HttpMethod.Get, "https://localhost/test");
            using var cts = new CancellationTokenSource();

            _ = await invoker.SendAsync(request, cts.Token);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(tokenProvider.LastCancellationToken, Is.EqualTo(cts.Token));
                Assert.That(lastInnerCancellationToken, Is.EqualTo(cts.Token));
            }
        }
    }
}
