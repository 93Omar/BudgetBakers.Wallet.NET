using FluentResults;
using Wallet.Api.Net.Dtos.Stats;
using Wallet.Api.Net.Models.Stats;
using Wallet.Api.Net.Services.Mappers;

namespace Wallet.Api.Net.Services.Clients
{
    public class StatsClient : IWalletClient
    {
        private readonly HttpClient _httpClient;
        private readonly IMapper<GetStatsRequest, GetStatsRequestDto> _getStatsRequestMapper = new GetStatsRequestMapper();
        private readonly IMapper<GetStatsResponseDto, GetStatsResponse> _getStatsResponseMapper = new GetStatsResponseMapper();

        public StatsClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<Result<GetStatsResponse>> GetAsync(GetStatsRequest request, CancellationToken ct = default)
            => WalletApiGetExecutor.ExecuteAsync<GetStatsRequest, GetStatsRequestDto, GetStatsResponseDto, GetStatsResponse>(
                _httpClient,
                "/wallet/v1/api/api-usage/stats",
                request,
                _getStatsRequestMapper,
                _getStatsResponseMapper,
                ct);
    }
}
