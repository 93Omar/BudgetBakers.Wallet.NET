using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text;
using Wallet.Api.Net.Dtos.StandingOrder;
using Wallet.Api.Net.Models.StandingOrder;
using Wallet.Api.Net.Utility;

namespace Wallet.Api.Net.Services.Clients
{
    public class StandingOrderClient
    {
        private readonly HttpClient _httpClient;
        private readonly IMapper<GetStandingOrdersRequest, GetStandingOrdersRequestDto> _getStandingOrdersRequestMapper;
        private readonly IMapper<GetStandingOrdersResponseDto, GetStandingOrdersResponse> _getStandingOrdersResponseMapper;

        public StandingOrderClient(HttpClient httpClient, IMapper<GetStandingOrdersRequest, GetStandingOrdersRequestDto> getStandingOrdersRequestMapper,
            IMapper<GetStandingOrdersResponseDto, GetStandingOrdersResponse> getStandingOrdersResponseMapper)
        {
            _httpClient = httpClient;
            _getStandingOrdersRequestMapper = getStandingOrdersRequestMapper;
            _getStandingOrdersResponseMapper = getStandingOrdersResponseMapper;
        }

        public async Task<GetStandingOrdersResponse?> GetAsync(GetStandingOrdersRequest request, CancellationToken ct = default)
        {
            string methodName = "/wallet/v1/api/standing-orders";

            GetStandingOrdersRequestDto? requestDto = _getStandingOrdersRequestMapper.Map(request);
            string? queryString = requestDto.ToQueryString();

            string methodAndParams = $"{methodName}?{queryString}";

            GetStandingOrdersResponseDto? responseDto = await _httpClient.GetFromJsonAsync<GetStandingOrdersResponseDto>(methodAndParams, ct);
            GetStandingOrdersResponse? response = _getStandingOrdersResponseMapper.Map(responseDto);

            return response;
        }
    }
}
