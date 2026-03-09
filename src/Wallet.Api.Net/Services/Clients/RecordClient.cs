using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text;
using Wallet.Api.Net.Dtos.Record;
using Wallet.Api.Net.Models.Record;
using Wallet.Api.Net.Utility;

namespace Wallet.Api.Net.Services.Clients
{
    public class RecordClient
    {
        private readonly HttpClient _httpClient;
        private readonly IMapper<GetRecordsRequest, GetRecordsRequestDto> _getRecordsRequestMapper;
        private readonly IMapper<GetRecordsResponseDto, GetRecordsResponse> _getRecordsResponseMapper;
        private readonly IMapper<GetRecordsByIdRequest, GetRecordsByIdRequestDto> _getRecordsByIdRequestMapper;
        private readonly IMapper<GetRecordsByIdResponseDto, GetRecordsByIdResponse> _getRecordsByIdResponseMapper;

        public RecordClient(HttpClient httpClient, IMapper<GetRecordsRequest, GetRecordsRequestDto> getRecordsRequestMapper,
            IMapper<GetRecordsResponseDto, GetRecordsResponse> getRecordsResponseMapper,
            IMapper<GetRecordsByIdRequest, GetRecordsByIdRequestDto> getRecordsByIdRequestMapper,
            IMapper<GetRecordsByIdResponseDto, GetRecordsByIdResponse> getRecordsByIdResponseMapper)
        {
            _httpClient = httpClient;
            _getRecordsRequestMapper = getRecordsRequestMapper;
            _getRecordsResponseMapper = getRecordsResponseMapper;
            _getRecordsByIdRequestMapper = getRecordsByIdRequestMapper;
            _getRecordsByIdResponseMapper = getRecordsByIdResponseMapper;
        }

        public async Task<GetRecordsResponse?> GetAsync(GetRecordsRequest request, CancellationToken ct = default)
        {
            string methodName = "/wallet/v1/api/records";

            GetRecordsRequestDto? requestDto = _getRecordsRequestMapper.Map(request);
            string? queryString = requestDto.ToQueryString();

            string methodAndParams = $"{methodName}?{queryString}";

            GetRecordsResponseDto? responseDto = await _httpClient.GetFromJsonAsync<GetRecordsResponseDto>(methodAndParams, ct);
            GetRecordsResponse? response = _getRecordsResponseMapper.Map(responseDto);

            return response;
        }

        public async Task<GetRecordsByIdResponse?> GetByIdAsync(GetRecordsByIdRequest request, CancellationToken ct = default)
        {
            string methodName = "/wallet/v1/api/records/by-id";

            GetRecordsByIdRequestDto? requestDto = _getRecordsByIdRequestMapper.Map(request);
            string? queryString = requestDto.ToQueryString();

            string methodAndParams = $"{methodName}?{queryString}";

            GetRecordsByIdResponseDto? responseDto = await _httpClient.GetFromJsonAsync<GetRecordsByIdResponseDto>(methodAndParams, ct);
            GetRecordsByIdResponse? response = _getRecordsByIdResponseMapper.Map(responseDto);

            return response;
        }
    }
}
