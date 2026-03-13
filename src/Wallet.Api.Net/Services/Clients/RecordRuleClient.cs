using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text;
using FluentResults;
using Wallet.Api.Net.Dtos.RecordRule;
using Wallet.Api.Net.Models.RecordRule;
using Wallet.Api.Net.Services.Mappers;

namespace Wallet.Api.Net.Services.Clients
{
    public class RecordRuleClient : IWalletClient
    {
        private readonly HttpClient _httpClient;
        private readonly IMapper<GetRecordRulesRequest, GetRecordRulesRequestDto> _getRecordRulesRequestMapper = new GetRecordRulesRequestMapper();
        private readonly IMapper<GetRecordRulesResponseDto, GetRecordRulesResponse> _getRecordRulesResponseMapper = new GetRecordRulesResponseMapper();

        public RecordRuleClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<Result<GetRecordRulesResponse>> GetAsync(GetRecordRulesRequest request, CancellationToken ct = default)
            => WalletApiGetExecutor.ExecuteAsync<GetRecordRulesRequest, GetRecordRulesRequestDto, GetRecordRulesResponseDto, GetRecordRulesResponse>(
                _httpClient,
                "/wallet/v1/api/record-rules",
                request,
                _getRecordRulesRequestMapper,
                _getRecordRulesResponseMapper,
                ct);
    }
}
