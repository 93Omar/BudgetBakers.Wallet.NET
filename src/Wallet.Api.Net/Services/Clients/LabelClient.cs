using FluentResults;
using Wallet.Api.Net.Dtos.Label;
using Wallet.Api.Net.Models.Label;
using Wallet.Api.Net.Services.Mappers;

namespace Wallet.Api.Net.Services.Clients
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
