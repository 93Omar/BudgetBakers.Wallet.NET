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

            Result<GetAccountsResponse> getAccountsResult = await accountClient.GetAsync(getAccountsRequest);

            if (getAccountsResult.IsFailed)
            {
                LogErrors(logger, getAccountsResult.Errors);
                await host.StopAsync();
            }

            GetAccountsResponse response = getAccountsResult.Value;
            logger.LogInformation("Accounts loaded successfully.");

            await host.StopAsync();
        }

        private static void LogErrors(ILogger logger, IReadOnlyList<IError> errors)
        {
            foreach (IError error in errors)
            {
                logger.LogError("Error: {ErrorMessage}", error.Message);
            }
        }
    }
}
