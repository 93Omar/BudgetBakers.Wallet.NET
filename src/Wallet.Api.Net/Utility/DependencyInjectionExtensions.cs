using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using Wallet.Api.Net.Dtos.Account;
using Wallet.Api.Net.Models.Account;
using Wallet.Api.Net.Services;
using Wallet.Api.Net.Services.Mappers;

namespace Wallet.Api.Net.Utility
{
    public static class DependencyInjectionExtensions
    {
        public static void AddWalletClient<T>(this IServiceCollection services, Action<HttpClient> configureClient)
            where T : class
        {
            RegisterServices(services);

            services.AddHttpClient<T>(configureClient)
                    .AddHttpMessageHandler<BearerTokenDelegatingHandler>();
        }

        public static void AddWalletClient<T>(this IServiceCollection services, Action<IServiceProvider, HttpClient> configureClient)
            where T : class
        {
            RegisterServices(services);

            services.AddHttpClient<T>(configureClient)
                    .AddHttpMessageHandler<BearerTokenDelegatingHandler>();
        }

        private static void RegisterServices(IServiceCollection services)
        {
            services.AddTransient<BearerTokenDelegatingHandler>();

            services.AddScoped<IMapper<GetAccountsRequest, GetAccountsRequestDto>, GetAccountsRequestMapper>();
            services.AddScoped<IMapper<GetAccountsResponseDto, GetAccountsResponse>, GetAccountsResponseMapper>();
        }
    }
}
