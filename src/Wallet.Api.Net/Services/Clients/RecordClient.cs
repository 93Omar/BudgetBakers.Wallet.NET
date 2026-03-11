using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text;
using FluentResults;
using Wallet.Api.Net.Dtos.Record;
using Wallet.Api.Net.Models.Record;
using Wallet.Api.Net.Services.Mappers;

namespace Wallet.Api.Net.Services.Clients
{
    public class RecordClient : IWalletClient
    {
        private readonly HttpClient _httpClient;
        private readonly IMapper<GetRecordsRequest, GetRecordsRequestDto> _getRecordsRequestMapper = new GetRecordsRequestMapper();
        private readonly IMapper<GetRecordsResponseDto, GetRecordsResponse> _getRecordsResponseMapper = new GetRecordsResponseMapper();
        private readonly IMapper<GetRecordsByIdRequest, GetRecordsByIdRequestDto> _getRecordsByIdRequestMapper = new GetRecordsByIdRequestMapper();
        private readonly IMapper<GetRecordsByIdResponseDto, GetRecordsByIdResponse> _getRecordsByIdResponseMapper = new GetRecordsByIdResponseMapper();

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

        public Task<Result<GetRecordsByIdResponse>> GetByIdAsync(GetRecordsByIdRequest request, CancellationToken ct = default)
            => WalletApiGetExecutor.ExecuteAsync<GetRecordsByIdRequest, GetRecordsByIdRequestDto, GetRecordsByIdResponseDto, GetRecordsByIdResponse>(
                _httpClient,
                "/wallet/v1/api/records/by-id",
                request,
                _getRecordsByIdRequestMapper,
                _getRecordsByIdResponseMapper,
                ct);
    }
}
