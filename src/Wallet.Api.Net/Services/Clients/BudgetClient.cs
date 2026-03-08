using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text;
using Wallet.Api.Net.Dtos.Account;
using Wallet.Api.Net.Dtos.Budget;
using Wallet.Api.Net.Models.Account;
using Wallet.Api.Net.Models.Budget;
using Wallet.Api.Net.Utility;

namespace Wallet.Api.Net.Services.Clients
{
    public class BudgetClient
    {
        private readonly HttpClient _httpClient;
        private readonly IMapper<GetBudgetsRequest, GetBudgetsRequestDto> _getBudgetsRequestMapper;
        private readonly IMapper<GetBudgetsResponseDto, GetBudgetsResponse> _getBudgetsResponseMapper;

        public BudgetClient(HttpClient httpClient, IMapper<GetBudgetsRequest, GetBudgetsRequestDto> getAccountsRequestMapper,
            IMapper<GetBudgetsResponseDto, GetBudgetsResponse> getAccountsResponseMapper)
        {
            _httpClient = httpClient;
            _getBudgetsRequestMapper = getAccountsRequestMapper;
            _getBudgetsResponseMapper = getAccountsResponseMapper;
        }

        public async Task<GetBudgetsResponse?> GetAsync(GetBudgetsRequest request, CancellationToken ct = default)
        {
            string methodName = "/wallet/v1/api/budgets";

            GetBudgetsRequestDto? requestDto = _getBudgetsRequestMapper.Map(request);
            string? queryString = requestDto.ToQueryString();

            string methodAndParams = $"{methodName}?{queryString}";

            GetBudgetsResponseDto? responseDto = await _httpClient.GetFromJsonAsync<GetBudgetsResponseDto>(methodAndParams, ct);
            GetBudgetsResponse? response = _getBudgetsResponseMapper.Map(responseDto);

            return response;
        }
    }
}
