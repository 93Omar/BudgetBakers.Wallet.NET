using Microsoft.Extensions.DependencyInjection;
using Wallet.Api.Net.Services;
using Wallet.Api.Net.Services.Clients;
using Wallet.Api.Net.Utility;

namespace Wallet.Api.Net.Tests.Utility
{
    public class DependencyInjectionExtensionsTests
    {
        private sealed class NoopAccessTokenProvider : IAccessTokenProvider
        {
            public Task<string> GetAccessTokenAsync(CancellationToken ct = default)
                => Task.FromResult("test-token");
        }

        private sealed class TestWalletClient : IWalletClient
        {
            public TestWalletClient(HttpClient httpClient)
            {
                HttpClient = httpClient;
            }

            public HttpClient HttpClient { get; }
        }

        [Test]
        public void AddWalletClient_WithHttpClientConfiguration_RegistersTypedClientAndBearerHandler()
        {
            var services = new ServiceCollection();

            services.AddSingleton<IAccessTokenProvider>(new NoopAccessTokenProvider());

            services.AddWalletClient<TestWalletClient>(client =>
            {
                client.BaseAddress = new Uri("https://wallet.test/");
            });

            using ServiceProvider provider = services.BuildServiceProvider();
            TestWalletClient client = provider.GetRequiredService<TestWalletClient>();

            using (Assert.EnterMultipleScope())
            {
                Assert.That(client, Is.Not.Null);
                Assert.That(client.HttpClient.BaseAddress, Is.EqualTo(new Uri("https://wallet.test/")));
                Assert.That(services.Any(descriptor =>
                    descriptor.ServiceType == typeof(BearerTokenDelegatingHandler)
                    && descriptor.Lifetime == ServiceLifetime.Transient), Is.True);
            }
        }

        [Test]
        public void AddWalletClient_WithServiceProviderConfiguration_RegistersTypedClientAndAppliesConfiguration()
        {
            var services = new ServiceCollection();
            services.AddSingleton<IAccessTokenProvider>(new NoopAccessTokenProvider());
            services.AddSingleton(new Uri("https://wallet-from-sp.test/"));

            services.AddWalletClient<TestWalletClient>((sp, client) =>
            {
                client.BaseAddress = sp.GetRequiredService<Uri>();
            });

            using ServiceProvider provider = services.BuildServiceProvider();
            TestWalletClient client = provider.GetRequiredService<TestWalletClient>();

            using (Assert.EnterMultipleScope())
            {
                Assert.That(client, Is.Not.Null);
                Assert.That(client.HttpClient.BaseAddress, Is.EqualTo(new Uri("https://wallet-from-sp.test/")));
                Assert.That(services.Any(descriptor =>
                    descriptor.ServiceType == typeof(BearerTokenDelegatingHandler)
                    && descriptor.Lifetime == ServiceLifetime.Transient), Is.True);
            }
        }
    }
}
