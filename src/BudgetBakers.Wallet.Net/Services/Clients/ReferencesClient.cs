using FluentResults;
using BudgetBakers.Wallet.Net.Dtos.References;
using BudgetBakers.Wallet.Net.Models.References;
using BudgetBakers.Wallet.Net.Services.Mappers;
using BudgetBakers.Wallet.Net.Utility;
using BudgetBakers.Wallet.Net.Services.Executors;

namespace BudgetBakers.Wallet.Net.Services.Clients
{
    public class ReferencesClient : IWalletClient
    {
        private readonly HttpClient _httpClient;
        private readonly IMapper<GetReferencesRequest, GetReferencesRequestDto> _requestMapper = new GetReferencesRequestMapper();
        private readonly IMapper<GetReferencesResponseDto, GetReferencesResponse> _responseMapper = new GetReferencesResponseMapper();

        public ReferencesClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<Result<GetReferencesResponse>> GetAsync(GetReferencesRequest request, CancellationToken ct = default)
            => WalletApiGetExecutor.ExecuteAsync<GetReferencesRequest, GetReferencesRequestDto, GetReferencesResponseDto, GetReferencesResponse>(
                _httpClient,
                $"/wallet/v1/api/{request?.EntityType.ToApiString()}/references",
                request!,
                _requestMapper,
                _responseMapper,
                ct);
    }
}
