using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using BudgetBakers.Wallet.Net.Services;
using BudgetBakers.Wallet.Net.Services.Clients;

namespace BudgetBakers.Wallet.Net.Utility
{
    public static class DependencyInjectionExtensions
    {
        public static void AddWalletClient<T>(this IServiceCollection services, Action<HttpClient> configureClient)
            where T : class, IWalletClient
        {
            RegisterServices(services);

            services.AddHttpClient<T>(configureClient)
                    .AddHttpMessageHandler<BearerTokenDelegatingHandler>()
                    .AddHttpMessageHandler<LoggingDelegatingHandler>();
        }

        public static void AddWalletClient<T>(this IServiceCollection services, Action<IServiceProvider, HttpClient> configureClient)
            where T : class, IWalletClient
        {
            RegisterServices(services);

            services.AddHttpClient<T>(configureClient)
                    .AddHttpMessageHandler<BearerTokenDelegatingHandler>()
                    .AddHttpMessageHandler<LoggingDelegatingHandler>();
        }

        public static void AddWalletClients(this IServiceCollection services, Action<HttpClient> configureClient)
        {
            services.AddWalletClient<AccountClient>(configureClient);
            services.AddWalletClient<RecordClient>(configureClient);
            services.AddWalletClient<CategoryClient>(configureClient);
            services.AddWalletClient<LabelClient>(configureClient);
            services.AddWalletClient<BudgetClient>(configureClient);
            services.AddWalletClient<DeleteClient>(configureClient);
            services.AddWalletClient<GoalClient>(configureClient);
            services.AddWalletClient<StandingOrderClient>(configureClient);
            services.AddWalletClient<StandingOrderItemClient>(configureClient);
            services.AddWalletClient<RecordRuleClient>(configureClient);
            services.AddWalletClient<StatsClient>(configureClient);
            services.AddWalletClient<ReferencesClient>(configureClient);
        }

        public static void AddWalletClients(this IServiceCollection services, Action<IServiceProvider, HttpClient> configureClient)
        {
            services.AddWalletClient<AccountClient>(configureClient);
            services.AddWalletClient<RecordClient>(configureClient);
            services.AddWalletClient<CategoryClient>(configureClient);
            services.AddWalletClient<LabelClient>(configureClient);
            services.AddWalletClient<BudgetClient>(configureClient);
            services.AddWalletClient<DeleteClient>(configureClient);
            services.AddWalletClient<GoalClient>(configureClient);
            services.AddWalletClient<StandingOrderClient>(configureClient);
            services.AddWalletClient<StandingOrderItemClient>(configureClient);
            services.AddWalletClient<RecordRuleClient>(configureClient);
            services.AddWalletClient<StatsClient>(configureClient);
            services.AddWalletClient<ReferencesClient>(configureClient);
        }

        private static void RegisterServices(IServiceCollection services)
        {
            services.AddTransient<BearerTokenDelegatingHandler>();
            services.AddTransient<LoggingDelegatingHandler>();
        }
    }
}
