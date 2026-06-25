using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text;
using FluentResults;
using BudgetBakers.Wallet.Net.Dtos.Category;
using BudgetBakers.Wallet.Net.Models.Category;
using BudgetBakers.Wallet.Net.Services.Mappers;

namespace BudgetBakers.Wallet.Net.Services.Clients
{
    public class CategoryClient : IWalletClient
    {
        private readonly HttpClient _httpClient;
        private readonly IMapper<GetCategoriesRequest, GetCategoriesRequestDto> _getCategoriesRequestMapper = new GetCategoriesRequestMapper();
        private readonly IMapper<GetCategoriesResponseDto, GetCategoriesResponse> _getCategoriesResponseMapper = new GetCategoriesResponseMapper();

        public CategoryClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<Result<GetCategoriesResponse>> GetAsync(GetCategoriesRequest request, CancellationToken ct = default)
            => WalletApiGetExecutor.ExecuteAsync<GetCategoriesRequest, GetCategoriesRequestDto, GetCategoriesResponseDto, GetCategoriesResponse>(
                _httpClient,
                "/wallet/v1/api/categories",
                request,
                _getCategoriesRequestMapper,
                _getCategoriesResponseMapper,
                ct);
    }
}
