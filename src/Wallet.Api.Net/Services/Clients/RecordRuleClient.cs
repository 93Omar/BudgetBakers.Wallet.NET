using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text;
using Wallet.Api.Net.Dtos.RecordRule;
using Wallet.Api.Net.Models.RecordRule;
using Wallet.Api.Net.Utility;

namespace Wallet.Api.Net.Services.Clients
{
    public class RecordRuleClient
    {
        private readonly HttpClient _httpClient;
        private readonly IMapper<GetRecordRulesRequest, GetRecordRulesRequestDto> _getRecordRulesRequestMapper;
        private readonly IMapper<GetRecordRulesResponseDto, GetRecordRulesResponse> _getRecordRulesResponseMapper;

        public RecordRuleClient(HttpClient httpClient, IMapper<GetRecordRulesRequest, GetRecordRulesRequestDto> getRecordRulesRequestMapper,
            IMapper<GetRecordRulesResponseDto, GetRecordRulesResponse> getRecordRulesResponseMapper)
        {
            _httpClient = httpClient;
            _getRecordRulesRequestMapper = getRecordRulesRequestMapper;
            _getRecordRulesResponseMapper = getRecordRulesResponseMapper;
        }

        public async Task<GetRecordRulesResponse?> GetAsync(GetRecordRulesRequest request, CancellationToken ct = default)
        {
            string methodName = "/wallet/v1/api/record-rules";

            GetRecordRulesRequestDto? requestDto = _getRecordRulesRequestMapper.Map(request);
            string? queryString = requestDto.ToQueryString();

            string methodAndParams = $"{methodName}?{queryString}";

            GetRecordRulesResponseDto? responseDto = await _httpClient.GetFromJsonAsync<GetRecordRulesResponseDto>(methodAndParams, ct);
            GetRecordRulesResponse? response = _getRecordRulesResponseMapper.Map(responseDto);

            return response;
        }
    }
}
