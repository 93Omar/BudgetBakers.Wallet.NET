using System.Net.Http.Json;
using FluentResults;
using Wallet.Api.Net.Utility;

namespace Wallet.Api.Net.Services.Clients
{
    internal static class WalletApiGetExecutor
    {
        private const string NullRequestMessage = "Request cannot be null.";
        private const string ApiNonSuccessMessage = "Wallet API returned a non-success status code.";
        private const string EmptyResponseBodyMessage = "Wallet API returned an empty response body.";

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
                return Result.Fail<TResponse>(new Error(NullRequestMessage).WithMetadata("Endpoint", endpoint));

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
                return Result.Fail<TResponse>(new Error(EmptyResponseBodyMessage).WithMetadata("Endpoint", endpoint));

            TResponse? response = responseMapper.Map(responseDto);

            if (response is null)
                return Result.Fail<TResponse>(CreateResponseMappingError<TResponseDto>(endpoint));

            return Result.Ok(response);
        }

        private static Error CreateRequestMappingError<TRequestDto>(string endpoint)
            => new Error($"Unable to map request to {typeof(TRequestDto).Name}.")
                .WithMetadata("Endpoint", endpoint);

        private static Error CreateResponseMappingError<TResponseDto>(string endpoint)
            => new Error($"Unable to map response DTO ({typeof(TResponseDto).Name}) to domain response.")
                .WithMetadata("Endpoint", endpoint);

        private static Error CreateApiError(string endpoint, HttpResponseMessage responseMessage, string? errorBody)
        {
            Error apiError = new Error(ApiNonSuccessMessage)
                .WithMetadata("Endpoint", endpoint)
                .WithMetadata("StatusCode", (int)responseMessage.StatusCode)
                .WithMetadata("ReasonPhrase", responseMessage.ReasonPhrase ?? string.Empty);

            if (!string.IsNullOrWhiteSpace(errorBody))
                apiError.WithMetadata("ResponseBody", errorBody);

            return apiError;
        }
    }
}
