using FluentResults;
using BudgetBakers.Wallet.Net.Dtos.StandingOrder;
using BudgetBakers.Wallet.Net.Models.StandingOrder;
using BudgetBakers.Wallet.Net.Services.Mappers;
using BudgetBakers.Wallet.Net.Services.Executors;

namespace BudgetBakers.Wallet.Net.Services.Clients
{
    public class StandingOrderItemClient : IWalletClient
    {
        private readonly HttpClient _httpClient;
        private readonly IMapper<GetStandingOrderItemsRequest, GetStandingOrderItemsRequestDto> _requestMapper = new GetStandingOrderItemsRequestMapper();
        private readonly IMapper<GetStandingOrderItemsResponseDto, GetStandingOrderItemsResponse> _responseMapper = new GetStandingOrderItemsResponseMapper();

        public StandingOrderItemClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<Result<GetStandingOrderItemsResponse>> GetAsync(GetStandingOrderItemsRequest request, CancellationToken ct = default)
            => WalletApiGetExecutor.ExecuteAsync<GetStandingOrderItemsRequest, GetStandingOrderItemsRequestDto, GetStandingOrderItemsResponseDto, GetStandingOrderItemsResponse>(
                _httpClient,
                "/wallet/v1/api/standing-orders/items",
                request,
                _requestMapper,
                _responseMapper,
                ct);
    }
}
