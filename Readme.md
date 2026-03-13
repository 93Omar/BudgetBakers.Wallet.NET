# Wallet.Api.Net

A .NET client library for the [BudgetBakers Wallet REST API](https://rest.budgetbakers.com/), targeting .NET 8, .NET 9, and .NET 10.

> The available clients mirror the endpoints documented in the official Wallet API:
> **[https://rest.budgetbakers.com/wallet/openapi/ui](https://rest.budgetbakers.com/wallet/openapi/ui)**

## Supported Frameworks

| Target Framework | Supported |
|---|---|
| .NET 8 | ✅ |
| .NET 9 | ✅ |
| .NET 10 | ✅ |

---

## Getting Started

### 1. Implement `IAccessTokenProvider`

All HTTP requests are authenticated with a Bearer token. You must provide a concrete implementation of `IAccessTokenProvider` that returns a valid access token:

```csharp
using Wallet.Api.Net.Services;

public class MyAccessTokenProvider : IAccessTokenProvider
{
    public Task<string> GetAccessTokenAsync(CancellationToken ct = default)
    {
        // Return your token however you retrieve it (config, secrets manager, OAuth flow, etc.)
        string token = "your-access-token-here";
        return Task.FromResult(token);
    }
}
```

The library automatically attaches the token as a `Bearer` authorization header on every outgoing request through its internal `BearerTokenDelegatingHandler`.

---

### 2. Register Services

Use the `AddWalletClient<T>` extension method on `IServiceCollection` to register a single client, or `AddWalletClients` to register all available clients at once. You must also register your `IAccessTokenProvider` implementation.

#### Register all clients

```csharp
using Wallet.Api.Net.Services;
using Wallet.Api.Net.Utility;

services.AddSingleton<IAccessTokenProvider, MyAccessTokenProvider>();

services.AddWalletClients(client =>
{
    client.BaseAddress = new Uri("https://rest.budgetbakers.com/");
});
```

#### Register a single client

If you only need a subset of clients, register them individually:

```csharp
using Wallet.Api.Net.Services;
using Wallet.Api.Net.Services.Clients;
using Wallet.Api.Net.Utility;

services.AddSingleton<IAccessTokenProvider, MyAccessTokenProvider>();

services.AddWalletClient<AccountClient>(client =>
{
    client.BaseAddress = new Uri("https://rest.budgetbakers.com/");
});

services.AddWalletClient<RecordClient>(client =>
{
    client.BaseAddress = new Uri("https://rest.budgetbakers.com/");
});
```

Both `AddWalletClients` and `AddWalletClient<T>` provide an overload that accepts `Action<IServiceProvider, HttpClient>` when you need access to the service provider during configuration:

```csharp
services.AddWalletClients((serviceProvider, client) =>
{
    client.BaseAddress = new Uri("https://rest.budgetbakers.com/");
});
```

---

### 3. Use the Clients

Inject the desired client and call `GetAsync`. Every method returns a `Result<T>` from the [FluentResults](https://github.com/altmann/FluentResults) library, so you should always check `IsSuccess` before accessing the value.

```csharp
using FluentResults;
using Wallet.Api.Net.Models.Account;
using Wallet.Api.Net.Services.Clients;

public class MyService
{
    private readonly AccountClient _accountClient;

    public MyService(AccountClient accountClient)
    {
        _accountClient = accountClient;
    }

    public async Task RunAsync(CancellationToken ct = default)
    {
        GetAccountsRequest request = new GetAccountsRequest
        {
            Limit = 20,
            Offset = 0
        };

        Result<GetAccountsResponse> result = await _accountClient.GetAsync(request, ct);

        if (result.IsSuccess)
        {
            GetAccountsResponse response = result.Value;
            // use response.Accounts, response.Pagination, etc.
        }
        else
        {
            foreach (IError error in result.Errors)
            {
                Console.WriteLine($"Error: {error.Message}");
            }
        }
    }
}
```

---

## Without Dependency Injection

If you prefer not to use a DI container, use `WalletClientFactory.CreateHttpClient` to obtain a pre-configured `HttpClient` with the Bearer token handler already attached, then pass it directly to any client constructor.

```csharp
using Wallet.Api.Net.Services;
using Wallet.Api.Net.Services.Clients;
using Wallet.Api.Net.Utility;

IAccessTokenProvider tokenProvider = new MyAccessTokenProvider();

HttpClient httpClient = WalletClientFactory.CreateHttpClient(tokenProvider, client =>
{
    client.BaseAddress = new Uri("https://rest.budgetbakers.com/");
});

AccountClient accountClient = new AccountClient(httpClient);

Result<GetAccountsResponse> result = await accountClient.GetAsync(new GetAccountsRequest { Limit = 20 });
```

`WalletClientFactory.CreateHttpClient` internally constructs the `BearerTokenDelegatingHandler` (which is `internal` to the library) and wires it up with a standard `HttpClientHandler` as its inner handler, so no additional setup is required.

> **Note:** The returned `HttpClient` is owned by the caller. Dispose it when it is no longer needed, or reuse a single instance for the lifetime of your application.

---

## Available Clients

Each client corresponds to a resource group in the [Wallet OpenAPI specification](https://rest.budgetbakers.com/wallet/openapi/ui). The request and response models map directly to the parameters and schemas described there.

| Client | Method | Description |
|---|---|---|
| `AccountClient` | `GetAsync(GetAccountsRequest)` | Retrieves the list of accounts |
| `RecordClient` | `GetAsync(GetRecordsRequest)` | Retrieves transactions/records |
| `RecordClient` | `GetByIdAsync(GetRecordsByIdRequest)` | Retrieves records by their IDs |
| `CategoryClient` | `GetAsync(GetCategoriesRequest)` | Retrieves categories |
| `LabelClient` | `GetAsync(GetLabelsRequest)` | Retrieves labels |
| `BudgetClient` | `GetAsync(GetBudgetsRequest)` | Retrieves budgets |
| `GoalClient` | `GetAsync(GetGoalsRequest)` | Retrieves savings goals |
| `StandingOrderClient` | `GetAsync(GetStandingOrdersRequest)` | Retrieves standing orders |
| `RecordRuleClient` | `GetAsync(GetRecordRulesRequest)` | Retrieves record rules |
| `StatsClient` | `GetAsync(GetStatsRequest)` | Retrieves API usage statistics |

---

## Example: Console Application

The `src/examples/ConsoleApp` project demonstrates a complete setup using .NET Generic Host and [user secrets](https://learn.microsoft.com/en-us/aspnet/core/security/app-secrets) to supply the access token.

### Configuration

The example ships with `OptionsAccessTokenProvider`, which reads the token from `IOptions<WalletOptions>`:

```json
// secrets.json (managed via `dotnet user-secrets`)
{
  "Wallet": {
    "AccessToken": "your-access-token-here"
  }
}
```

To set the secret from the command line:

```shell
dotnet user-secrets set "Wallet:AccessToken" "your-access-token-here" --project src/examples/ConsoleApp
```

### Program Setup

```csharp
using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration((_, config) => config.AddUserSecrets<Program>())
    .ConfigureServices((context, services) =>
    {
        services.Configure<WalletOptions>(context.Configuration.GetSection(WalletOptions.SectionName));

        services.AddSingleton<IAccessTokenProvider, OptionsAccessTokenProvider>();

        services.AddWalletClient<AccountClient>(client =>
        {
            client.BaseAddress = new Uri("https://rest.budgetbakers.com/");
        });
    })
    .Build();
