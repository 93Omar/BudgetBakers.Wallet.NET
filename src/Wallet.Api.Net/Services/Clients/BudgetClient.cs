using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text;
using FluentResults;
using Wallet.Api.Net.Dtos.Budget;
using Wallet.Api.Net.Models.Budget;
using Wallet.Api.Net.Services.Mappers;

namespace Wallet.Api.Net.Services.Clients
{
    public class BudgetClient : IWalletClient
    {
        private readonly HttpClient _httpClient;
        private readonly IMapper<GetBudgetsRequest, GetBudgetsRequestDto> _getBudgetsRequestMapper = new GetBudgetsRequestMapper();
        private readonly IMapper<GetBudgetsResponseDto, GetBudgetsResponse> _getBudgetsResponseMapper = new GetBudgetsResponseMapper();

        public BudgetClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<Result<GetBudgetsResponse>> GetAsync(GetBudgetsRequest request, CancellationToken ct = default)
            => WalletApiGetExecutor.ExecuteAsync<GetBudgetsRequest, GetBudgetsRequestDto, GetBudgetsResponseDto, GetBudgetsResponse>(
                _httpClient,
                "/wallet/v1/api/budgets",
                request,
                _getBudgetsRequestMapper,
                _getBudgetsResponseMapper,
                ct);
    }
}
