using ConsoleApp.Configuration;
using ConsoleApp.Services;
using FluentResults;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using BudgetBakers.Wallet.Net.Models.Account;
using BudgetBakers.Wallet.Net.Services;
using BudgetBakers.Wallet.Net.Services.Clients;
using BudgetBakers.Wallet.Net.Utility;

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

                    services.AddSingleton<IAccessTokenProvider, OptionsAccessTokenProvider>();

                    services.AddWalletClient<AccountClient>(client =>
                    {
                        client.BaseAddress = new Uri("https://rest.budgetbakers.com/");
                    });
                })
                .Build();

            ILogger<Program> logger = host.Services.GetRequiredService<ILogger<Program>>();

            logger.LogInformation("Starting application...");

            AccountClient accountClient = host.Services.GetRequiredService<AccountClient>();

            GetAccountsRequest getAccountsRequest = new GetAccountsRequest()
            {
                Limit = 30,
                Offset = 0
            };

            Result<GetAccountsResponse> result = await accountClient.GetAsync(getAccountsRequest);

            if (result.IsSuccess)
            {
                GetAccountsResponse response = result.Value;
                logger.LogInformation("Accounts loaded successfully.");
            }
            else
            {
                foreach (IError error in result.Errors)
                {
                    logger.LogError("Error loading accounts: {ErrorMessage}", error.Message);
                }
            }

            await host.StopAsync();
        }
    }
}
