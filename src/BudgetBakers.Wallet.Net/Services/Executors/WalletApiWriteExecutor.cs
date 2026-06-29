using System.Net.Http.Json;
using System.Text;
using BudgetBakers.Wallet.Net.Constants;
using BudgetBakers.Wallet.Net.Services.Clients;
using BudgetBakers.Wallet.Net.Utility;
using FluentResults;
using Newtonsoft.Json;

namespace BudgetBakers.Wallet.Net.Services.Executors
{
    internal static class WalletApiWriteExecutor
    {
        private static readonly JsonSerializerSettings _jsonSettings = new()
        {
            NullValueHandling = NullValueHandling.Ignore
        };

        public static async Task<Result<TResponse>> ExecuteAsync<TRequest, TRequestBodyDto, TResponseDto, TResponse>(
            HttpClient httpClient,
            HttpMethod method,
            string endpoint,
            TRequest request,
            IMapper<TRequest, TRequestBodyDto> requestMapper,
            IMapper<TResponseDto, TResponse> responseMapper,
            string? queryString = null,
            CancellationToken ct = default)
            where TRequest : class
            where TRequestBodyDto : class
            where TResponseDto : class
            where TResponse : class
        {
            if (request is null)
                return Result.Fail<TResponse>(new Error(ApiConstant.Message.NullRequest).WithMetadata(ApiConstant.Metadata.Endpoint, endpoint));

            TRequestBodyDto? requestDto = requestMapper.Map(request);

            if (requestDto is null)
                return Result.Fail<TResponse>(new Error($"Unable to map request to {typeof(TRequestBodyDto).Name}.").WithMetadata(ApiConstant.Metadata.Endpoint, endpoint));

            string json = JsonConvert.SerializeObject(requestDto, _jsonSettings);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            string url = string.IsNullOrEmpty(queryString) ? endpoint : $"{endpoint}?{queryString}";
            var httpRequest = new HttpRequestMessage(method, url) { Content = content };

            using HttpResponseMessage responseMessage = await httpClient.SendAsync(httpRequest, ct);

            if (!responseMessage.IsSuccessStatusCode)
            {
                string errorBody = await responseMessage.Content.ReadAsStringAsync(ct);
                Error apiError = new Error(ApiConstant.Message.ApiNonSuccess)
                    .WithMetadata(ApiConstant.Metadata.Endpoint, endpoint)
                    .WithMetadata(ApiConstant.Metadata.StatusCode, (int)responseMessage.StatusCode)
                    .WithMetadata(ApiConstant.Metadata.ReasonPhrase, responseMessage.ReasonPhrase ?? string.Empty);
                if (!string.IsNullOrWhiteSpace(errorBody))
                    apiError.WithMetadata(ApiConstant.Metadata.ResponseBody, errorBody);
                return Result.Fail<TResponse>(apiError);
            }

            TResponseDto? responseDto = await responseMessage.Content.ReadFromJsonAsync<TResponseDto>(cancellationToken: ct);

            if (responseDto is null)
                return Result.Fail<TResponse>(new Error(ApiConstant.Message.EmptyResponseBody).WithMetadata(ApiConstant.Metadata.Endpoint, endpoint));

            TResponse? response = responseMapper.Map(responseDto);

            if (response is null)
                return Result.Fail<TResponse>(new Error($"Unable to map response DTO ({typeof(TResponseDto).Name}) to domain response.").WithMetadata(ApiConstant.Metadata.Endpoint, endpoint));

            ResponseHeaderMapper.Apply(responseMessage, response);

            return Result.Ok(response);
        }
    }
}
