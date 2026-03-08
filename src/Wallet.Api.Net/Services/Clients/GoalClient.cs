using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text;
using Wallet.Api.Net.Dtos.Goal;
using Wallet.Api.Net.Models.Goal;
using Wallet.Api.Net.Utility;

namespace Wallet.Api.Net.Services.Clients
{
    public class GoalClient
    {
        private readonly HttpClient _httpClient;
        private readonly IMapper<GetGoalsRequest, GetGoalsRequestDto> _getGoalsRequestMapper;
        private readonly IMapper<GetGoalsResponseDto, GetGoalsResponse> _getGoalsResponseMapper;

        public GoalClient(HttpClient httpClient, IMapper<GetGoalsRequest, GetGoalsRequestDto> getGoalsRequestMapper,
            IMapper<GetGoalsResponseDto, GetGoalsResponse> getGoalsResponseMapper)
        {
            _httpClient = httpClient;
            _getGoalsRequestMapper = getGoalsRequestMapper;
            _getGoalsResponseMapper = getGoalsResponseMapper;
        }

        public async Task<GetGoalsResponse?> GetAsync(GetGoalsRequest request, CancellationToken ct = default)
        {
            string methodName = "/wallet/v1/api/goals";

            GetGoalsRequestDto? requestDto = _getGoalsRequestMapper.Map(request);
            string? queryString = requestDto.ToQueryString();

            string methodAndParams = $"{methodName}?{queryString}";

            GetGoalsResponseDto? responseDto = await _httpClient.GetFromJsonAsync<GetGoalsResponseDto>(methodAndParams, ct);
            GetGoalsResponse? response = _getGoalsResponseMapper.Map(responseDto);

            return response;
        }
    }
}
