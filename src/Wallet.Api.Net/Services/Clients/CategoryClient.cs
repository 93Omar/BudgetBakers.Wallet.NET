using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text;
using Wallet.Api.Net.Dtos.Category;
using Wallet.Api.Net.Models.Category;
using Wallet.Api.Net.Utility;

namespace Wallet.Api.Net.Services.Clients
{
    public class CategoryClient
    {
        private readonly HttpClient _httpClient;
        private readonly IMapper<GetCategoriesRequest, GetCategoriesRequestDto> _getCategoriesRequestMapper;
        private readonly IMapper<GetCategoriesResponseDto, GetCategoriesResponse> _getCategoriesResponseMapper;

        public CategoryClient(HttpClient httpClient, IMapper<GetCategoriesRequest, GetCategoriesRequestDto> getCategoriesRequestMapper,
            IMapper<GetCategoriesResponseDto, GetCategoriesResponse> getCategoriesResponseMapper)
        {
            _httpClient = httpClient;
            _getCategoriesRequestMapper = getCategoriesRequestMapper;
            _getCategoriesResponseMapper = getCategoriesResponseMapper;
        }

        public async Task<GetCategoriesResponse?> GetAsync(GetCategoriesRequest request, CancellationToken ct = default)
        {
            string methodName = "/wallet/v1/api/categories";

            GetCategoriesRequestDto? requestDto = _getCategoriesRequestMapper.Map(request);
            string? queryString = requestDto.ToQueryString();

            string methodAndParams = $"{methodName}?{queryString}";

            GetCategoriesResponseDto? responseDto = await _httpClient.GetFromJsonAsync<GetCategoriesResponseDto>(methodAndParams, ct);
            GetCategoriesResponse? response = _getCategoriesResponseMapper.Map(responseDto);

            return response;
        }
    }
}
