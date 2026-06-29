using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text;
using FluentResults;
using BudgetBakers.Wallet.Net.Dtos.StandingOrder;
using BudgetBakers.Wallet.Net.Models.StandingOrder;
using BudgetBakers.Wallet.Net.Services.Mappers;
using BudgetBakers.Wallet.Net.Services.Executors;

namespace BudgetBakers.Wallet.Net.Services.Clients
{
    public class StandingOrderClient : IWalletClient
    {
        private readonly HttpClient _httpClient;
        private readonly IMapper<GetStandingOrdersRequest, GetStandingOrdersRequestDto> _getStandingOrdersRequestMapper = new GetStandingOrdersRequestMapper();
        private readonly IMapper<GetStandingOrdersResponseDto, GetStandingOrdersResponse> _getStandingOrdersResponseMapper = new GetStandingOrdersResponseMapper();

        public StandingOrderClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<Result<GetStandingOrdersResponse>> GetAsync(GetStandingOrdersRequest request, CancellationToken ct = default)
            => WalletApiGetExecutor.ExecuteAsync<GetStandingOrdersRequest, GetStandingOrdersRequestDto, GetStandingOrdersResponseDto, GetStandingOrdersResponse>(
                _httpClient,
                "/wallet/v1/api/standing-orders",
                request,
                _getStandingOrdersRequestMapper,
                _getStandingOrdersResponseMapper,
                ct);
    }
}
