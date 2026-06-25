using FluentResults;
using BudgetBakers.Wallet.Net.Dtos.Label;
using BudgetBakers.Wallet.Net.Models.Label;
using BudgetBakers.Wallet.Net.Services.Mappers;

namespace BudgetBakers.Wallet.Net.Services.Clients
{
    public class LabelClient : IWalletClient
    {
        private readonly HttpClient _httpClient;
        private readonly IMapper<GetLabelsRequest, GetLabelsRequestDto> _getLabelsRequestMapper = new GetLabelsRequestMapper();
        private readonly IMapper<GetLabelsResponseDto, GetLabelsResponse> _getLabelsResponseMapper = new GetLabelsResponseMapper();

        public LabelClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<Result<GetLabelsResponse>> GetAsync(GetLabelsRequest request, CancellationToken ct = default)
            => WalletApiGetExecutor.ExecuteAsync<GetLabelsRequest, GetLabelsRequestDto, GetLabelsResponseDto, GetLabelsResponse>(
                _httpClient,
                "/wallet/v1/api/labels",
                request,
                _getLabelsRequestMapper,
                _getLabelsResponseMapper,
                ct);
    }
}
