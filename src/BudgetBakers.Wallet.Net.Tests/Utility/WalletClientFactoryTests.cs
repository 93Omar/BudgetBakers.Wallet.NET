using System;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using BudgetBakers.Wallet.Net.Tests.Infrastructure;
using BudgetBakers.Wallet.Net.Tests.Services;
using BudgetBakers.Wallet.Net.Utility;

namespace BudgetBakers.Wallet.Net.Tests.Utility
{
    public class WalletClientFactoryTests
    {
        [Test]
        public void CreateHttpClient_AppliesConfigureClientAction()
        {
            TestAccessTokenProvider tokenProvider = new TestAccessTokenProvider("test-token");
            Uri expectedBaseAddress = new Uri("https://wallet.test/");

            using HttpClient client = WalletClientFactory.CreateHttpClient(tokenProvider, c =>
            {
                c.BaseAddress = expectedBaseAddress;
            });

            Assert.That(client.BaseAddress, Is.EqualTo(expectedBaseAddress));
        }

        [Test]
        public async Task CreateHttpClient_WhenRequestIsSent_SetsBearerAuthorizationHeader()
        {
            TestAccessTokenProvider tokenProvider = new TestAccessTokenProvider("my-token");
            HttpRequestMessage? capturedRequest = null;

            using HttpClient client = WalletClientFactory.CreateHttpClient(tokenProvider, c =>
            {
                c.BaseAddress = new Uri("https://wallet.test/");
            });

            ReplaceInnerHandler(client, new DelegateHttpMessageHandler((request, _) =>
            {
                capturedRequest = request;
                return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK));
            }));

            await client.GetAsync("/test");

            using (Assert.EnterMultipleScope())
            {
                Assert.That(capturedRequest, Is.Not.Null);
                Assert.That(capturedRequest!.Headers.Authorization, Is.Not.Null);
                Assert.That(capturedRequest.Headers.Authorization!.Scheme, Is.EqualTo("Bearer"));
                Assert.That(capturedRequest.Headers.Authorization.Parameter, Is.EqualTo("my-token"));
            }
        }

        private static void ReplaceInnerHandler(HttpClient client, HttpMessageHandler replacement)
        {
            FieldInfo? field = typeof(HttpMessageInvoker)
                .GetField("_handler", BindingFlags.NonPublic | BindingFlags.Instance);

            DelegatingHandler outerHandler = (DelegatingHandler)field!.GetValue(client)!;
            outerHandler.InnerHandler = replacement;
        }
    }
}
