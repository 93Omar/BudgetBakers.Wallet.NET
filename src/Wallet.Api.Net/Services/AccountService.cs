using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text;
using Wallet.Api.Net.Dtos.Account;
using Wallet.Api.Net.Models.Account;
using Wallet.Api.Net.Utility;

namespace Wallet.Api.Net.Services
{
    public class AccountService
    {
        private readonly HttpClient _httpClient;
        private readonly IMapper<GetAccountsRequest, GetAccountsRequestDto> _getAccountsRequestMapper;
        private readonly IMapper<GetAccountsResponseDto, GetAccountsResponse> _getAccountsResponseMapper;

        public AccountService(HttpClient httpClient, IMapper<GetAccountsRequest, GetAccountsRequestDto> getAccountsRequestMapper,
            IMapper<GetAccountsResponseDto, GetAccountsResponse> getAccountsResponseMapper)
        {
            _httpClient = httpClient;
            _getAccountsRequestMapper = getAccountsRequestMapper;
            _getAccountsResponseMapper = getAccountsResponseMapper;
        }

        public async Task<GetAccountsResponse?> GetAsync(GetAccountsRequest request, CancellationToken ct = default)
        {
            string methodName = "/api/accounts";

            GetAccountsRequestDto? requestDto = _getAccountsRequestMapper.Map(request);
            string? queryString = requestDto.ToQueryString();

            string methodAndParams = $"{methodName}?{queryString}";

            GetAccountsResponseDto? responseDto = await _httpClient.GetFromJsonAsync<GetAccountsResponseDto>(methodAndParams, ct);
            GetAccountsResponse? response = _getAccountsResponseMapper.Map(responseDto);

            return response;
        }
    }
}
