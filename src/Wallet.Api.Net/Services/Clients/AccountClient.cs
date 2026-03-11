using FluentResults;
using Wallet.Api.Net.Dtos.Account;
using Wallet.Api.Net.Models.Account;
using Wallet.Api.Net.Services.Mappers;

namespace Wallet.Api.Net.Services.Clients
{
    public class AccountClient : IWalletClient
    {
        private readonly HttpClient _httpClient;
        private readonly IMapper<GetAccountsRequest, GetAccountsRequestDto> _getAccountsRequestMapper = new GetAccountsRequestMapper();
        private readonly IMapper<GetAccountsResponseDto, GetAccountsResponse> _getAccountsResponseMapper = new GetAccountsResponseMapper();

        public AccountClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<Result<GetAccountsResponse>> GetAsync(GetAccountsRequest request, CancellationToken ct = default)
            => WalletApiGetExecutor.ExecuteAsync<GetAccountsRequest, GetAccountsRequestDto, GetAccountsResponseDto, GetAccountsResponse>(
                _httpClient,
                "/wallet/v1/api/accounts",
                request,
                _getAccountsRequestMapper,
                _getAccountsResponseMapper,
                ct);
    }
}
