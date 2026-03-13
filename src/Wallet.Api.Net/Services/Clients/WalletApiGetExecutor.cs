using System.Net.Http.Json;
using FluentResults;
using Wallet.Api.Net.Constants;
using Wallet.Api.Net.Utility;

namespace Wallet.Api.Net.Services.Clients
{
    internal static class WalletApiGetExecutor
    {
        public static async Task<Result<TResponse>> ExecuteAsync<TRequest, TRequestDto, TResponseDto, TResponse>(
            HttpClient httpClient,
            string endpoint,
            TRequest request,
            IMapper<TRequest, TRequestDto> requestMapper,
            IMapper<TResponseDto, TResponse> responseMapper,
            CancellationToken ct = default)
            where TRequest : class
            where TRequestDto : class
            where TResponseDto : class
            where TResponse : class
        {
            if (request is null)
                return Result.Fail<TResponse>(new Error(ApiConstant.Message.NullRequest).WithMetadata(ApiConstant.Metadata.Endpoint, endpoint));

            TRequestDto? requestDto = requestMapper.Map(request);

            if (requestDto is null)
                return Result.Fail<TResponse>(CreateRequestMappingError<TRequestDto>(endpoint));

            string? queryString = requestDto.ToQueryString();
            string methodAndParams = string.IsNullOrWhiteSpace(queryString) ? endpoint : $"{endpoint}?{queryString}";

            using HttpResponseMessage responseMessage = await httpClient.GetAsync(methodAndParams, ct);

            if (!responseMessage.IsSuccessStatusCode)
            {
                string errorBody = await responseMessage.Content.ReadAsStringAsync(ct);
                return Result.Fail<TResponse>(CreateApiError(endpoint, responseMessage, errorBody));
            }

            TResponseDto? responseDto = await responseMessage.Content.ReadFromJsonAsync<TResponseDto>(cancellationToken: ct);

            if (responseDto is null)
                return Result.Fail<TResponse>(new Error(ApiConstant.Message.EmptyResponseBody).WithMetadata(ApiConstant.Metadata.Endpoint, endpoint));

            TResponse? response = responseMapper.Map(responseDto);

            if (response is null)
                return Result.Fail<TResponse>(CreateResponseMappingError<TResponseDto>(endpoint));

            ResponseHeaderMapper.Apply(responseMessage, response);

            return Result.Ok(response);
        }

        private static Error CreateRequestMappingError<TRequestDto>(string endpoint)
            => new Error($"Unable to map request to {typeof(TRequestDto).Name}.")
                .WithMetadata(ApiConstant.Metadata.Endpoint, endpoint);

        private static Error CreateResponseMappingError<TResponseDto>(string endpoint)
            => new Error($"Unable to map response DTO ({typeof(TResponseDto).Name}) to domain response.")
                .WithMetadata(ApiConstant.Metadata.Endpoint, endpoint);

        private static Error CreateApiError(string endpoint, HttpResponseMessage responseMessage, string? errorBody)
        {
            Error apiError = new Error(ApiConstant.Message.ApiNonSuccess)
                .WithMetadata(ApiConstant.Metadata.Endpoint, endpoint)
                .WithMetadata(ApiConstant.Metadata.StatusCode, (int)responseMessage.StatusCode)
                .WithMetadata(ApiConstant.Metadata.ReasonPhrase, responseMessage.ReasonPhrase ?? string.Empty);

            AddRateLimitMetadata(apiError, responseMessage);

            if (!string.IsNullOrWhiteSpace(errorBody))
                apiError.WithMetadata(ApiConstant.Metadata.ResponseBody, errorBody);

            return apiError;
        }

        private static void AddRateLimitMetadata(Error apiError, HttpResponseMessage responseMessage)
        {
            int? rateLimitLimit = responseMessage.TryGetIntHeaderValue(ApiConstant.Header.RateLimitLimit);
            if (rateLimitLimit.HasValue)
                apiError.WithMetadata(ApiConstant.Metadata.RateLimitLimit, rateLimitLimit.Value);

            int? rateLimitRemaining = responseMessage.TryGetIntHeaderValue(ApiConstant.Header.RateLimitRemaining);
            if (rateLimitRemaining.HasValue)
                apiError.WithMetadata(ApiConstant.Metadata.RateLimitRemaining, rateLimitRemaining.Value);

            int? retryAfter = responseMessage.TryGetIntHeaderValue(ApiConstant.Header.RetryAfter);
            if (retryAfter.HasValue)
                apiError.WithMetadata(ApiConstant.Metadata.RetryAfter, retryAfter.Value);
        }
    }
}
