using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text;
using FluentResults;
using Wallet.Api.Net.Dtos.Goal;
using Wallet.Api.Net.Models.Goal;
using Wallet.Api.Net.Services.Mappers;

namespace Wallet.Api.Net.Services.Clients
{
    public class GoalClient : IWalletClient
    {
        private readonly HttpClient _httpClient;
        private readonly IMapper<GetGoalsRequest, GetGoalsRequestDto> _getGoalsRequestMapper = new GetGoalsRequestMapper();
        private readonly IMapper<GetGoalsResponseDto, GetGoalsResponse> _getGoalsResponseMapper = new GetGoalsResponseMapper();

        public GoalClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<Result<GetGoalsResponse>> GetAsync(GetGoalsRequest request, CancellationToken ct = default)
            => WalletApiGetExecutor.ExecuteAsync<GetGoalsRequest, GetGoalsRequestDto, GetGoalsResponseDto, GetGoalsResponse>(
                _httpClient,
                "/wallet/v1/api/goals",
                request,
                _getGoalsRequestMapper,
                _getGoalsResponseMapper,
                ct);
    }
}
