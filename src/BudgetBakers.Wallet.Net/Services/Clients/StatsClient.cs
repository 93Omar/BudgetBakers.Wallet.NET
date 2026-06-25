using FluentResults;
using BudgetBakers.Wallet.Net.Dtos.Stats;
using BudgetBakers.Wallet.Net.Models.Stats;
using BudgetBakers.Wallet.Net.Services.Mappers;

namespace BudgetBakers.Wallet.Net.Services.Clients
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
