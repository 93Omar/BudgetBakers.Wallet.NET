# Contributing to BudgetBakers.Wallet.NET

Thanks for taking the time to contribute! This is an **unofficial, community-maintained** .NET wrapper for the
[BudgetBakers Wallet REST API](https://rest.budgetbakers.com/wallet/openapi/ui).

## Questions and contact

- **Bug reports / feature requests** — open an [issue](https://github.com/93Omar/BudgetBakers.Wallet.NET/issues) and
  include the upstream API version (see [`openapi/`](../openapi)), the request you sent, and the response or error
  metadata you got back.
- **Anything else, including security reports** — email **omar-93@outlook.it**. Please report vulnerabilities privately
  by email instead of opening a public issue.

## Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download) **8**, **9**, and **10** — the library multi-targets
  `net8.0;net9.0;net10.0`, so a full build and test run requires all three SDKs.
- A .NET-compatible IDE is optional; everything below runs from the command line.

## Build and test

```shell
# Build the whole solution
dotnet build BudgetBakers.Wallet.Net.slnx

# Run the full test suite (Coverlet coverage report: src/BudgetBakers.Wallet.Net.Tests/coverage_report/)
dotnet test src/BudgetBakers.Wallet.Net.Tests/BudgetBakers.Wallet.Net.Tests.csproj

# Run a single test
dotnet test src/BudgetBakers.Wallet.Net.Tests/BudgetBakers.Wallet.Net.Tests.csproj \
  --filter "FullyQualifiedName~AccountClientTests.GetAsync_WhenResponseIsSuccessful_ReturnsSuccess"
```

`TreatWarningsAsErrors` is enabled in both projects: **zero warnings are allowed**. Treat a warning as a build failure
and fix it before opening a pull request.

## OpenAPI is the source of truth

The `openapi/` folder holds the official Wallet API specification, one JSON file per upstream version. The highest
version number in that folder is the API version the repository currently targets. When adding or changing anything
that touches the wire contract, **check the spec first** — endpoint paths, query parameter names, response schemas, enum
string values, and response headers are all defined there.

When a new upstream version is released:

1. Add `openapi/<major>.<minor>.<patch>.json`.
2. Add the corresponding `openapi/diff_<old>_<new>.json` describing what changed.
3. Implement the alignment in a `development/openapi_v.<version>` branch and open a PR against `master`.

## Code conventions

### Everything returns `Result<T>`

Public API methods never throw for API-level errors. They return
[FluentResults](https://github.com/altmann/FluentResults) `Result<T>` values, and error metadata uses the keys defined in
`ApiConstant.Metadata` (`StatusCode`, `Endpoint`, `RateLimitRemaining`, ...).

### Dual JSON library usage

- **Request DTOs** use Newtonsoft.Json `[JsonProperty("camelCaseName")]` — the keys feed the query string built by
  `QueryStringExtensions.ToQueryString()`.
- **Response DTOs** use System.Text.Json `[JsonPropertyName("camelCaseName")]` — responses are read with
  `ReadFromJsonAsync`.

Never mix the two on the same DTO, and keep property names exactly as the spec spells them.

### Enums, not raw strings

Any field or query parameter with a fixed set of string values is a C# enum in `Models/<Area>/`. DTOs keep the raw
`string?`.

- Outbound (`Model` → `DTO`): add a `ToApiString()` extension in `Utility/<EnumName>Extensions.cs`.
- Inbound (`DTO` → `Model`): add `MapperHelpers.Parse<EnumName>(string?)` backed by a
  `private static readonly Dictionary<string, TEnum> _<camelCaseEnumName>Map`.
- Return `null` for `null` input; throw `InvalidOperationException` for unmapped/unknown values. Never fall back
  silently and never use `Enum.Parse`.

### Multi-value filters are `IList<string>`

A query parameter that accepts multiple values is modeled as `IList<string>` (default `= []`), not a pre-joined
`string?`. The mapper collapses it with `MapperHelpers.JoinIds(...)`. XML docs on such properties describe the filter
semantics and limits ("max 10") but never mention "comma-separated" — that is a wire-format detail.

### Adding a client — checklist

1. `Models/<Resource>/Get<Resource>Request.cs` — extend `PaginatedRequest`.
2. `Models/<Resource>/Get<Resource>Response.cs` — implement `IPaginatedResponse`, `IRateLimitResponse`,
   `IDataSynchronizationResponse` as appropriate.
3. `Dtos/<Resource>/Get<Resource>RequestDto.cs` — Newtonsoft `[JsonProperty]`.
4. `Dtos/<Resource>/Get<Resource>ResponseDto.cs` — System.Text.Json `[JsonPropertyName]`.
5. `Services/Mappers/Get<Resource>RequestMapper.cs` and `Get<Resource>ResponseMapper.cs`.
6. `Services/Clients/<Resource>Client.cs` — takes `HttpClient` in the constructor, creates its mappers inline (not via
   DI), and delegates to `WalletApiGetExecutor.ExecuteAsync`.
7. Register the client in `DependencyInjectionExtensions.AddWalletClients`.
8. Add unit tests and, where useful, a JSON fixture under
   `src/BudgetBakers.Wallet.Net.Tests/Data/Dtos/`.

Response headers are mapped automatically by `ResponseHeaderMapper.Apply()` — no per-client code needed.

### Write operations

Some clients wrap endpoints that create or modify data. Treat them with extreme care: verify a single-record call before
scaling up, and never add batch create/update logic without confirming the payload contract against the spec.

## Tests

- NUnit 4; group related asserts with `Assert.EnterMultipleScope()`.
- Use `ClientTestHelpers.CreateHttpClient(responder)` to build an `HttpClient` backed by a stub handler.
- Add tests only for behavior your change introduces or fixes — a few focused cases that fail without the change.

## Pull requests

- Branch from `master` and name it `development/<short-description>` — API alignment branches use
  `development/openapi_v.<version>`, other work uses something like `development/record-sort-by`.
- Keep commits focused and write imperative messages (e.g. `Implemented multiple filters and parsed
  appliedRecordDateFilters`).
- Make sure `dotnet build` and `dotnet test` pass locally before opening the PR.
- Describe **what** changed and **why**, and mention the upstream API version if the contract changed.
- A tag matching `v<major>.<minor>.<patch>` (or `-prerelease`) on `master` triggers the NuGet publish workflow, so do not
  push tags in a pull request.

## License

By contributing you agree that your contributions are licensed under the [MIT License](../LICENSE).
