using System.Collections.Generic;
using FluentResults;
using BudgetBakers.Wallet.Net.Dtos.Record;
using BudgetBakers.Wallet.Net.Models.Record;
using BudgetBakers.Wallet.Net.Services.Executors;
using BudgetBakers.Wallet.Net.Services.Mappers;

namespace BudgetBakers.Wallet.Net.Services.Clients
{
    public class RecordClient : IWalletClient
    {
        private readonly HttpClient _httpClient;
        private readonly IMapper<GetRecordsRequest, GetRecordsRequestDto> _getRecordsRequestMapper = new GetRecordsRequestMapper();
        private readonly IMapper<GetRecordsResponseDto, GetRecordsResponse> _getRecordsResponseMapper = new GetRecordsResponseMapper();
        private readonly IMapper<CreateRecordsRequest, List<CreateRecordItemDto>> _createRecordsRequestMapper = new CreateRecordsRequestMapper();
        private readonly IMapper<CreateRecordsResponseDto, CreateRecordsResponse> _createRecordsResponseMapper = new CreateRecordsResponseMapper();
        private readonly IMapper<UpdateRecordsRequest, List<UpdateRecordItemDto>> _updateRecordsRequestMapper = new UpdateRecordsRequestMapper();
        private readonly IMapper<UpdateRecordsResponseDto, UpdateRecordsResponse> _updateRecordsResponseMapper = new UpdateRecordsResponseMapper();

        public RecordClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<Result<GetRecordsResponse>> GetAsync(GetRecordsRequest request, CancellationToken ct = default)
            => WalletApiGetExecutor.ExecuteAsync<GetRecordsRequest, GetRecordsRequestDto, GetRecordsResponseDto, GetRecordsResponse>(
                _httpClient,
                "/wallet/v1/api/records",
                request,
                _getRecordsRequestMapper,
                _getRecordsResponseMapper,
                ct);

        public Task<Result<CreateRecordsResponse>> CreateAsync(CreateRecordsRequest request, CancellationToken ct = default)
        {
            string? qs = request is not null && request.ReturnData == true ? "returnData=true" : null;
            return WalletApiWriteExecutor.ExecuteAsync<CreateRecordsRequest, List<CreateRecordItemDto>, CreateRecordsResponseDto, CreateRecordsResponse>(
                _httpClient,
                HttpMethod.Post,
                "/wallet/v1/api/records",
                request!,
                _createRecordsRequestMapper,
                _createRecordsResponseMapper,
                qs,
                ct);
        }

        public Task<Result<UpdateRecordsResponse>> UpdateAsync(UpdateRecordsRequest request, CancellationToken ct = default)
        {
            List<string> parts = [];
            if (request is not null && request.ValidationStrict == true)
                parts.Add("validation=strict");
            if (request is not null && request.ReturnData == true)
                parts.Add("returnData=true");

            string? qs = parts.Count > 0 ? string.Join("&", parts) : null;
            return WalletApiWriteExecutor.ExecuteAsync<UpdateRecordsRequest, List<UpdateRecordItemDto>, UpdateRecordsResponseDto, UpdateRecordsResponse>(
                _httpClient,
                HttpMethod.Patch,
                "/wallet/v1/api/records",
                request!,
                _updateRecordsRequestMapper,
                _updateRecordsResponseMapper,
                qs,
                ct);
        }
    }
}
