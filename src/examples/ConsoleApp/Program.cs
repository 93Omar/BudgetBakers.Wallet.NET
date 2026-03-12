using ConsoleApp.Configuration;
using ConsoleApp.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using Wallet.Api.Net.Models.Account;
using Wallet.Api.Net.Services;
using Wallet.Api.Net.Services.Clients;
using Wallet.Api.Net.Utility;

namespace ConsoleApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            using IHost host = Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    config.AddUserSecrets<Program>(optional: false);
                })
                .ConfigureServices((context, services) =>
                {
                    services.AddLogging(config => config.AddConsole());

                    services.Configure<WalletOptions>(context.Configuration.GetSection(WalletOptions.SectionName));

                    services.AddSingleton<IAccessTokenProvider, UserSecretsAccessTokenProvider>();

                    services.AddWalletClient<AccountClient>(client =>
                    {
                        client.BaseAddress = new Uri("https://rest.budgetbakers.com/");
                    });
                })
                .Build();

            var logger = host.Services.GetRequiredService<ILogger<Program>>();

            logger.LogInformation("Starting application...");

            AccountClient accountClient = host.Services.GetRequiredService<AccountClient>();

            GetAccountsRequest getAccountsRequest = new GetAccountsRequest()
            {
                Limit = 30,
                Offset = 0
            };

            var result = await accountClient.GetAsync(getAccountsRequest);

            if (result.IsSuccess)
            {
                GetAccountsResponse response = result.Value;
                logger.LogInformation("Accounts loaded successfully.");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    logger.LogError("Error loading accounts: {ErrorMessage}", error.Message);
                }
            }

            await host.StopAsync();
        }
    }
}
