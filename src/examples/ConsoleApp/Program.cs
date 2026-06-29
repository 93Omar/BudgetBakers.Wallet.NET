using BudgetBakers.Wallet.Net.Models;
using BudgetBakers.Wallet.Net.Models.Account;
using BudgetBakers.Wallet.Net.Models.Record;
using BudgetBakers.Wallet.Net.Services;
using BudgetBakers.Wallet.Net.Services.Clients;
using BudgetBakers.Wallet.Net.Utility;
using ConsoleApp.Configuration;
using ConsoleApp.Services;
using FluentResults;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

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

                    services.AddWalletClients(client =>
                    {
                        client.BaseAddress = new Uri("https://rest.budgetbakers.com/");
                    });
                })
                .Build();

            ILogger<Program> logger = host.Services.GetRequiredService<ILogger<Program>>();

            logger.LogInformation("Starting application...");

            AccountClient accountClient = host.Services.GetRequiredService<AccountClient>();
            RecordClient recordClient = host.Services.GetRequiredService<RecordClient>();

            GetAccountsRequest getAccountsRequest = new GetAccountsRequest()
            {
                AccountType = AccountType.CurrentAccount,
                Limit = 30,
                Offset = 0
            };

            Result<GetAccountsResponse> getAccountsResult = await accountClient.GetAsync(getAccountsRequest);

            if (getAccountsResult.IsFailed)
            {
                LogErrors(logger, getAccountsResult.Errors);
                await host.StopAsync();
            }

            GetAccountsResponse accountsResponse = getAccountsResult.Value;
            logger.LogInformation("Accounts loaded successfully.");

            GetRecordsRequest getRecordsRequest = new GetRecordsRequest()
            {
                AccountId = accountsResponse.Accounts.First().Id,
                Limit = 50,
                Offset = 0,
                RecordDate = new DateFilter()
                {
                    Prefix = RangePrefix.GreaterThanOrEqual,
                    Value = new DateTime(2026, 1, 1)
                },
                WithTotal = true
            };

            Result<GetRecordsResponse> getRecordsResponse = await recordClient.GetAsync(getRecordsRequest);

            if (getRecordsResponse.IsFailed)
            {
                LogErrors(logger, getRecordsResponse.Errors);
                await host.StopAsync();
            }

            GetRecordsResponse recordsResponse = getRecordsResponse.Value;
            logger.LogInformation("Retrieved {number} records.", recordsResponse.Records.Count);

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
