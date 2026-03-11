using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using Wallet.Api.Net.Services;
using Wallet.Api.Net.Services.Clients;

namespace Wallet.Api.Net.Utility
{
    public static class DependencyInjectionExtensions
    {
        public static void AddWalletClient<T>(this IServiceCollection services, Action<HttpClient> configureClient)
            where T : class, IWalletClient
        {
            RegisterServices(services);

            services.AddHttpClient<T>(configureClient)
                    .AddHttpMessageHandler<BearerTokenDelegatingHandler>();
        }

        public static void AddWalletClient<T>(this IServiceCollection services, Action<IServiceProvider, HttpClient> configureClient)
            where T : class, IWalletClient
        {
            RegisterServices(services);

            services.AddHttpClient<T>(configureClient)
                    .AddHttpMessageHandler<BearerTokenDelegatingHandler>();
        }

        private static void RegisterServices(IServiceCollection services)
        {
            services.AddTransient<BearerTokenDelegatingHandler>();
        }
    }
}
