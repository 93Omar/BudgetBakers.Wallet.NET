# Copilot Instructions

## Build & Test

```bash
# Build (multi-targets net8.0, net9.0, net10.0)
dotnet build BudgetBakers.Wallet.Net.slnx

# Run all tests
dotnet test src/BudgetBakers.Wallet.Net.Tests/BudgetBakers.Wallet.Net.Tests.csproj

# Run a single test by name
dotnet test src/BudgetBakers.Wallet.Net.Tests/BudgetBakers.Wallet.Net.Tests.csproj \
  --filter "FullyQualifiedName~AccountClientTests.GetAsync_WhenResponseIsSuccessful_ReturnsSuccess"
```

`TreatWarningsAsErrors` is enabled in both projects — all warnings are build errors.

Coverage is collected automatically via Coverlet when running tests; an HTML report is generated at `src/BudgetBakers.Wallet.Net.Tests/coverage_report/`.

---

## Architecture

This is a read-only .NET client library for the [BudgetBakers Wallet REST API](https://rest.budgetbakers.com/wallet/openapi/ui).

### Data flow per request

```
Domain Request model
      ↓  RequestMapper (IMapper<TRequest, TRequestDto>)
Request DTO  →  ToQueryString()  →  GET /endpoint?params
                                          ↓
                               HTTP response body (JSON)
                                          ↓
                              ReadFromJsonAsync<TResponseDto>
                                          ↓
                          ResponseMapper (IMapper<TResponseDto, TResponse>)
                                          ↓
                            Domain Response model
                                    +
                          ResponseHeaderMapper.Apply()
                        (populates RateLimit / DataSynchronization)
```

`WalletApiGetExecutor.ExecuteAsync` (in `Services/Clients/WalletApiGetExecutor.cs`) is the single internal execution engine shared by every client. It handles null-guard, query-string building, HTTP GET, error wrapping, deserialization, and header mapping.

### Project layout

| Path | Purpose |
|---|---|
| `src/BudgetBakers.Wallet.Net/` | Library (multi-target) |
| `src/BudgetBakers.Wallet.Net/Models/` | Public domain models (requests, responses, enums) |
| `src/BudgetBakers.Wallet.Net/Dtos/` | Internal DTO layer mirroring JSON shapes |
| `src/BudgetBakers.Wallet.Net/Services/Clients/` | Client classes + `WalletApiGetExecutor` |
| `src/BudgetBakers.Wallet.Net/Services/Mappers/` | Internal request/response mappers |
| `src/BudgetBakers.Wallet.Net/Utility/` | DI extensions, `WalletClientFactory`, helpers |
| `src/BudgetBakers.Wallet.Net.Tests/` | NUnit test project |
| `src/BudgetBakers.Wallet.Net.Tests/Data/Dtos/` | JSON fixture files for deserialization tests |
| `src/examples/ConsoleApp/` | Full DI example using user-secrets |
| `openapi/` | Wallet API OpenAPI spec (1.3.0.json) |

---

## OpenAPI Specification

The `openapi/` folder contains the official Wallet REST API specification as versioned JSON files (e.g. `1.3.0.json`). This is the **authoritative reference** for everything the library wraps: endpoint paths, query parameter names, request/response schemas, and response header definitions.

### When to consult the spec
- **Adding a new client or endpoint** — verify the exact endpoint path, query parameter names (these become `[JsonProperty]` keys on request DTOs), and the full response schema.
- **Adding or updating a DTO** — the spec's `components/schemas` section lists every field name, type, nullability, and allowed enum values. Response DTO property names must match the JSON keys in the spec exactly.
- **Understanding enum string values** — the spec enumerates the raw string values (e.g. `"cash"`, `"debit_card"`) that the API sends; these are the keys used in `MapperHelpers` dictionaries.
- **Response headers** — rate-limit and data-synchronization headers (`X-RateLimit-Limit`, `X-RateLimit-Remaining`, `Retry-After`, `X-Last-Data-Change-At`, `X-Last-Data-Change-Rev`, `X-Sync-In-Progress`) are defined in the spec's `components/headers` section and map directly to the constants in `ApiConstant.Header`.

### File naming convention
Files are named after the API version they describe (`<major>.<minor>.<patch>.json`). When the upstream API releases a new version, add the new spec file under `openapi/` with the corresponding version number before updating or adding library code.

### Note on scope
The current library only exposes **GET** (read) endpoints. The spec also documents **POST/PATCH/DELETE** write operations — those are not yet implemented. Do not add write support without a corresponding spec file confirming the request/response contract.

---

## Key Conventions

### All public API methods return `Result<T>` (FluentResults)
Never throw for API-level errors. Check `result.IsSuccess` / `result.IsFailed`. Error metadata keys are defined in `ApiConstant.Metadata` (e.g. `StatusCode`, `Endpoint`, `RateLimitRemaining`).

### Adding a new client — follow the exact pattern
Every client (`AccountClient`, `RecordClient`, etc.) follows the same structure:
1. **Model** in `Models/<Resource>/Get<Resource>Request.cs` — extend `PaginatedRequest`.
2. **Model** in `Models/<Resource>/Get<Resource>Response.cs` — implement `IPaginatedResponse`, `IRateLimitResponse`, `IDataSynchronizationResponse` as appropriate.
3. **DTO** in `Dtos/<Resource>/Get<Resource>RequestDto.cs` — properties annotated with `[JsonProperty("camelCaseName")]` (Newtonsoft).
4. **DTO** in `Dtos/<Resource>/Get<Resource>ResponseDto.cs` — properties annotated with `[JsonPropertyName("camelCaseName")]` (System.Text.Json), because responses are deserialized with `ReadFromJsonAsync`.
5. **RequestMapper** and **ResponseMapper** in `Services/Mappers/`.
6. **Client class** in `Services/Clients/` — takes `HttpClient` in constructor, creates mappers inline (not via DI), delegates to `WalletApiGetExecutor.ExecuteAsync`.
7. **Register** the new client in `DependencyInjectionExtensions.AddWalletClients`.

### Dual JSON library usage
- **Newtonsoft.Json** `[JsonProperty]` — used only on **request DTOs** to name query-string keys (via `QueryStringExtensions.ToQueryString()`).
- **System.Text.Json** `[JsonPropertyName]` — used on **response DTOs** for `ReadFromJsonAsync` deserialization.

### Enum string mapping
String-to-enum conversions use static `Dictionary<string, TEnum>` lookup tables in `MapperHelpers`. Unknown values **throw `InvalidOperationException`** — do not use `Enum.Parse` or ignore unknowns.

### IDs filter → comma-separated string
When a request model has an `IList<string> Ids` filter, `MapperHelpers.JoinIds()` collapses it to a single comma-separated `id` query parameter (separator defined in `ApiConstant.Separator.Ids`).

### Response header mapping
Responses implementing `IRateLimitResponse` or `IDataSynchronizationResponse` have their extra info populated from HTTP headers automatically by `ResponseHeaderMapper.Apply()`. No client-level code needed.

### `IWalletClient` is a marker interface
It is empty — its only purpose is to constrain the `AddWalletClient<T>` generic parameter.

### `BearerTokenDelegatingHandler` is internal
External callers obtain a pre-wired `HttpClient` via `WalletClientFactory.CreateHttpClient(tokenProvider, configure)` when not using DI.

### Test helpers
- `ClientTestHelpers.CreateHttpClient(responder)` — creates an `HttpClient` backed by a `DelegateHttpMessageHandler` that invokes the provided `Func<HttpRequestMessage, CancellationToken, Task<HttpResponseMessage>>`.
- JSON fixture files under `Data/Dtos/**/*.json` are copied to output and used by `ResponseDtosJsonDeserializationTests`.
- Use `Assert.EnterMultipleScope()` for grouped assertions (NUnit 4 style used throughout).
