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

        private static readonly Type[] AllClientTypes =
        [
            typeof(AccountClient),
            typeof(RecordClient),
            typeof(CategoryClient),
            typeof(LabelClient),
            typeof(BudgetClient),
            typeof(GoalClient),
            typeof(StandingOrderClient),
            typeof(RecordRuleClient),
            typeof(StatsClient)
        ];

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

        [Test]
        public void AddWalletClients_WithHttpClientConfiguration_RegistersAllClients()
        {
            ServiceCollection services = new ServiceCollection();
            services.AddSingleton<IAccessTokenProvider>(new NoopAccessTokenProvider());

            services.AddWalletClients(client =>
            {
                client.BaseAddress = new Uri("https://wallet.test/");
            });

            using ServiceProvider provider = services.BuildServiceProvider();

            foreach (System.Type clientType in AllClientTypes)
            {
                object? resolved = provider.GetService(clientType);
                Assert.That(resolved, Is.Not.Null, $"{clientType.Name} was not registered.");
            }
        }

        [Test]
        public void AddWalletClients_WithServiceProviderConfiguration_RegistersAllClients()
        {
            ServiceCollection services = new ServiceCollection();
            services.AddSingleton<IAccessTokenProvider>(new NoopAccessTokenProvider());
            services.AddSingleton(new Uri("https://wallet.test/"));

            services.AddWalletClients((sp, client) =>
            {
                client.BaseAddress = sp.GetRequiredService<Uri>();
            });

            using ServiceProvider provider = services.BuildServiceProvider();

            foreach (System.Type clientType in AllClientTypes)
            {
                object? resolved = provider.GetService(clientType);
                Assert.That(resolved, Is.Not.Null, $"{clientType.Name} was not registered.");
            }
        }
    }
}
