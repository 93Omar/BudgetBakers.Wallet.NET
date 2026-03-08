using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text;
using Wallet.Api.Net.Dtos.Label;
using Wallet.Api.Net.Models.Label;
using Wallet.Api.Net.Utility;

namespace Wallet.Api.Net.Services.Clients
{
    public class LabelClient
    {
        private readonly HttpClient _httpClient;
        private readonly IMapper<GetLabelsRequest, GetLabelsRequestDto> _getLabelsRequestMapper;
        private readonly IMapper<GetLabelsResponseDto, GetLabelsResponse> _getLabelsResponseMapper;

        public LabelClient(HttpClient httpClient, IMapper<GetLabelsRequest, GetLabelsRequestDto> getLabelsRequestMapper,
            IMapper<GetLabelsResponseDto, GetLabelsResponse> getLabelsResponseMapper)
        {
            _httpClient = httpClient;
            _getLabelsRequestMapper = getLabelsRequestMapper;
            _getLabelsResponseMapper = getLabelsResponseMapper;
        }

        public async Task<GetLabelsResponse?> GetAsync(GetLabelsRequest request, CancellationToken ct = default)
        {
            string methodName = "/wallet/v1/api/labels";

            GetLabelsRequestDto? requestDto = _getLabelsRequestMapper.Map(request);
            string? queryString = requestDto.ToQueryString();

            string methodAndParams = $"{methodName}?{queryString}";

            GetLabelsResponseDto? responseDto = await _httpClient.GetFromJsonAsync<GetLabelsResponseDto>(methodAndParams, ct);
            GetLabelsResponse? response = _getLabelsResponseMapper.Map(responseDto);

            return response;
        }
    }
}
