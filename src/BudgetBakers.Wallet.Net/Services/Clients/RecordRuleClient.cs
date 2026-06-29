using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text;
using FluentResults;
using BudgetBakers.Wallet.Net.Dtos.RecordRule;
using BudgetBakers.Wallet.Net.Models.RecordRule;
using BudgetBakers.Wallet.Net.Services.Mappers;
using BudgetBakers.Wallet.Net.Services.Executors;

namespace BudgetBakers.Wallet.Net.Services.Clients
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
