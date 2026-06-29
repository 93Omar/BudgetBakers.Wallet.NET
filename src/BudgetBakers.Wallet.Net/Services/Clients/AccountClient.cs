using FluentResults;
using BudgetBakers.Wallet.Net.Constants;
using BudgetBakers.Wallet.Net.Dtos.Account;
using BudgetBakers.Wallet.Net.Models.Account;
using BudgetBakers.Wallet.Net.Services.Executors;
using BudgetBakers.Wallet.Net.Services.Mappers;

namespace BudgetBakers.Wallet.Net.Services.Clients
{
    public class AccountClient : IWalletClient
    {
        private readonly HttpClient _httpClient;
        private readonly IMapper<GetAccountsRequest, GetAccountsRequestDto> _getAccountsRequestMapper = new GetAccountsRequestMapper();
        private readonly IMapper<GetAccountsResponseDto, GetAccountsResponse> _getAccountsResponseMapper = new GetAccountsResponseMapper();
        private readonly IMapper<CreateAccountRequest, CreateAccountRequestDto> _createAccountRequestMapper = new CreateAccountRequestMapper();
        private readonly IMapper<CreateAccountResponseDto, CreateAccountResponse> _createAccountResponseMapper = new CreateAccountResponseMapper();
        private readonly IMapper<UpdateAccountsRequest, List<UpdateAccountItemDto>> _updateAccountsRequestMapper = new UpdateAccountsRequestMapper();
        private readonly IMapper<UpdateAccountsResponseDto, UpdateAccountsResponse> _updateAccountsResponseMapper = new UpdateAccountsResponseMapper();

        public AccountClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<Result<GetAccountsResponse>> GetAsync(GetAccountsRequest request, CancellationToken ct = default)
            => WalletApiGetExecutor.ExecuteAsync<GetAccountsRequest, GetAccountsRequestDto, GetAccountsResponseDto, GetAccountsResponse>(
                _httpClient,
                ApiConstant.Endpoint.Accounts,
                request,
                _getAccountsRequestMapper,
                _getAccountsResponseMapper,
                ct);

        public Task<Result<CreateAccountResponse>> CreateAsync(CreateAccountRequest request, CancellationToken ct = default)
            => WalletApiWriteExecutor.ExecuteAsync<CreateAccountRequest, CreateAccountRequestDto, CreateAccountResponseDto, CreateAccountResponse>(
                _httpClient,
                HttpMethod.Post,
                ApiConstant.Endpoint.Accounts,
                request,
                _createAccountRequestMapper,
                _createAccountResponseMapper,
                ct: ct);

        public Task<Result<UpdateAccountsResponse>> UpdateAsync(UpdateAccountsRequest request, CancellationToken ct = default)
            => WalletApiWriteExecutor.ExecuteAsync<UpdateAccountsRequest, List<UpdateAccountItemDto>, UpdateAccountsResponseDto, UpdateAccountsResponse>(
                _httpClient,
                HttpMethod.Patch,
                ApiConstant.Endpoint.Accounts,
                request,
                _updateAccountsRequestMapper,
                _updateAccountsResponseMapper,
                ct: ct);
    }
}
