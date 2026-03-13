using System.Net;
using System.Text;
using FluentResults;
using Wallet.Api.Net.Constants;
using Wallet.Api.Net.Services.Clients;
using Wallet.Api.Net.Tests.Infrastructure;

namespace Wallet.Api.Net.Tests.Clients
{
    public class WalletApiGetExecutorTests
    {
        [Test]
        public async Task ExecuteAsync_WhenRequestIsNull_ReturnsNullRequestError()
        {
            var client = ClientTestHelpers.CreateHttpClient((_, _) =>
                Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)));

            Result<WalletApiGetExecutorTestResponse> result = await WalletApiGetExecutor.ExecuteAsync<
                WalletApiGetExecutorTestRequest,
                WalletApiGetExecutorTestRequestDto,
                WalletApiGetExecutorTestResponseDto,
                WalletApiGetExecutorTestResponse>(
                client,
                "/endpoint",
                null!,
                new DelegateMapper<WalletApiGetExecutorTestRequest, WalletApiGetExecutorTestRequestDto>(_ => new WalletApiGetExecutorTestRequestDto()),
                new DelegateMapper<WalletApiGetExecutorTestResponseDto, WalletApiGetExecutorTestResponse>(_ => new WalletApiGetExecutorTestResponse()),
                CancellationToken.None);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(result.IsFailed, Is.True);
                Assert.That(result.Errors[0].Message, Is.EqualTo(ApiConstant.Message.NullRequest));
                Assert.That(result.Errors[0].Metadata[ApiConstant.Metadata.Endpoint], Is.EqualTo("/endpoint"));
            }
        }

        [Test]
        public async Task ExecuteAsync_WhenRequestMappingFails_ReturnsMappingError()
        {
            var client = ClientTestHelpers.CreateHttpClient((_, _) =>
                Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)));

            Result<WalletApiGetExecutorTestResponse> result = await WalletApiGetExecutor.ExecuteAsync<
                WalletApiGetExecutorTestRequest,
                WalletApiGetExecutorTestRequestDto,
                WalletApiGetExecutorTestResponseDto,
                WalletApiGetExecutorTestResponse>(
                client,
                "/endpoint",
                new WalletApiGetExecutorTestRequest(),
                new DelegateMapper<WalletApiGetExecutorTestRequest, WalletApiGetExecutorTestRequestDto>(_ => null),
                new DelegateMapper<WalletApiGetExecutorTestResponseDto, WalletApiGetExecutorTestResponse>(_ => new WalletApiGetExecutorTestResponse()),
                CancellationToken.None);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(result.IsFailed, Is.True);
                Assert.That(result.Errors[0].Message, Does.Contain("Unable to map request to"));
                Assert.That(result.Errors[0].Metadata[ApiConstant.Metadata.Endpoint], Is.EqualTo("/endpoint"));
            }
        }

        [Test]
        public async Task ExecuteAsync_WhenApiReturnsNonSuccessAndBodyPresent_AddsResponseBodyMetadata()
        {
            var client = ClientTestHelpers.CreateHttpClient((_, _) =>
                Task.FromResult(new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent("{\"error\":\"bad\"}", Encoding.UTF8, "application/json")
                }));

            Result<WalletApiGetExecutorTestResponse> result = await WalletApiGetExecutor.ExecuteAsync<
                WalletApiGetExecutorTestRequest,
                WalletApiGetExecutorTestRequestDto,
                WalletApiGetExecutorTestResponseDto,
                WalletApiGetExecutorTestResponse>(
                client,
                "/endpoint",
                new WalletApiGetExecutorTestRequest(),
                new DelegateMapper<WalletApiGetExecutorTestRequest, WalletApiGetExecutorTestRequestDto>(_ => new WalletApiGetExecutorTestRequestDto()),
                new DelegateMapper<WalletApiGetExecutorTestResponseDto, WalletApiGetExecutorTestResponse>(_ => new WalletApiGetExecutorTestResponse()),
                CancellationToken.None);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(result.IsFailed, Is.True);
                Assert.That(result.Errors[0].Metadata.ContainsKey(ApiConstant.Metadata.ResponseBody), Is.True);
                Assert.That(result.Errors[0].Metadata[ApiConstant.Metadata.StatusCode], Is.EqualTo((int)HttpStatusCode.BadRequest));
            }
        }

        [Test]
        public async Task ExecuteAsync_WhenApiReturnsNonSuccessAndBodyIsWhitespace_DoesNotAddResponseBodyMetadata()
        {
            var client = ClientTestHelpers.CreateHttpClient((_, _) =>
                Task.FromResult(new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent("   ", Encoding.UTF8, "application/json")
                }));

            Result<WalletApiGetExecutorTestResponse> result = await WalletApiGetExecutor.ExecuteAsync<
                WalletApiGetExecutorTestRequest,
                WalletApiGetExecutorTestRequestDto,
                WalletApiGetExecutorTestResponseDto,
                WalletApiGetExecutorTestResponse>(
                client,
                "/endpoint",
                new WalletApiGetExecutorTestRequest(),
                new DelegateMapper<WalletApiGetExecutorTestRequest, WalletApiGetExecutorTestRequestDto>(_ => new WalletApiGetExecutorTestRequestDto()),
                new DelegateMapper<WalletApiGetExecutorTestResponseDto, WalletApiGetExecutorTestResponse>(_ => new WalletApiGetExecutorTestResponse()),
                CancellationToken.None);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(result.IsFailed, Is.True);
                Assert.That(result.Errors[0].Metadata.ContainsKey(ApiConstant.Metadata.ResponseBody), Is.False);
                Assert.That(result.Errors[0].Metadata[ApiConstant.Metadata.StatusCode], Is.EqualTo((int)HttpStatusCode.BadRequest));
            }
        }

        [Test]
        public async Task ExecuteAsync_WhenApiReturnsNullJson_ReturnsEmptyResponseError()
        {
            var client = ClientTestHelpers.CreateHttpClient((_, _) =>
                Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = ClientTestHelpers.CreateJsonContent("null")
                }));

            Result<WalletApiGetExecutorTestResponse> result = await WalletApiGetExecutor.ExecuteAsync<
                WalletApiGetExecutorTestRequest,
                WalletApiGetExecutorTestRequestDto,
                WalletApiGetExecutorTestResponseDto,
                WalletApiGetExecutorTestResponse>(
                client,
                "/endpoint",
                new WalletApiGetExecutorTestRequest(),
                new DelegateMapper<WalletApiGetExecutorTestRequest, WalletApiGetExecutorTestRequestDto>(_ => new WalletApiGetExecutorTestRequestDto()),
                new DelegateMapper<WalletApiGetExecutorTestResponseDto, WalletApiGetExecutorTestResponse>(_ => new WalletApiGetExecutorTestResponse()),
                CancellationToken.None);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(result.IsFailed, Is.True);
                Assert.That(result.Errors[0].Message, Is.EqualTo(ApiConstant.Message.EmptyResponseBody));
                Assert.That(result.Errors[0].Metadata[ApiConstant.Metadata.Endpoint], Is.EqualTo("/endpoint"));
            }
        }

        [Test]
        public async Task ExecuteAsync_WhenResponseMappingFails_ReturnsMappingError()
        {
            var client = ClientTestHelpers.CreateHttpClient((_, _) =>
                Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = ClientTestHelpers.CreateJsonContent("{\"value\":\"ok\"}")
                }));

            Result<WalletApiGetExecutorTestResponse> result = await WalletApiGetExecutor.ExecuteAsync<
                WalletApiGetExecutorTestRequest,
                WalletApiGetExecutorTestRequestDto,
                WalletApiGetExecutorTestResponseDto,
                WalletApiGetExecutorTestResponse>(
                client,
                "/endpoint",
                new WalletApiGetExecutorTestRequest(),
                new DelegateMapper<WalletApiGetExecutorTestRequest, WalletApiGetExecutorTestRequestDto>(_ => new WalletApiGetExecutorTestRequestDto()),
                new DelegateMapper<WalletApiGetExecutorTestResponseDto, WalletApiGetExecutorTestResponse>(_ => null),
                CancellationToken.None);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(result.IsFailed, Is.True);
                Assert.That(result.Errors[0].Message, Does.Contain("Unable to map response DTO"));
                Assert.That(result.Errors[0].Metadata[ApiConstant.Metadata.Endpoint], Is.EqualTo("/endpoint"));
            }
        }

        [Test]
        public async Task ExecuteAsync_WhenEverythingIsValid_ReturnsSuccess()
        {
            var client = ClientTestHelpers.CreateHttpClient((_, _) =>
                Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = ClientTestHelpers.CreateJsonContent("{\"value\":\"ok\"}")
                }));

            Result<WalletApiGetExecutorTestResponse> result = await WalletApiGetExecutor.ExecuteAsync<
                WalletApiGetExecutorTestRequest,
                WalletApiGetExecutorTestRequestDto,
                WalletApiGetExecutorTestResponseDto,
                WalletApiGetExecutorTestResponse>(
                client,
                "/endpoint",
                new WalletApiGetExecutorTestRequest { Query = "q" },
                new DelegateMapper<WalletApiGetExecutorTestRequest, WalletApiGetExecutorTestRequestDto>(r => new WalletApiGetExecutorTestRequestDto { Query = r!.Query }),
                new DelegateMapper<WalletApiGetExecutorTestResponseDto, WalletApiGetExecutorTestResponse>(dto => new WalletApiGetExecutorTestResponse { Value = dto!.Value }),
                CancellationToken.None);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(result.IsSuccess, Is.True);
                Assert.That(result.Value.Value, Is.EqualTo("ok"));
            }
        }

        [Test]
        public async Task ExecuteAsync_WhenApiReturnsTooManyRequests_AddsRateLimitMetadata()
        {
            HttpResponseMessage tooManyRequestsResponse = new HttpResponseMessage(HttpStatusCode.TooManyRequests)
            {
                Content = new StringContent("{\"error\":\"too many requests\"}", Encoding.UTF8, "application/json")
            };
            tooManyRequestsResponse.Headers.Add(ApiConstant.Header.RetryAfter, "60");
            tooManyRequestsResponse.Headers.Add(ApiConstant.Header.RateLimitLimit, "500");
            tooManyRequestsResponse.Headers.Add(ApiConstant.Header.RateLimitRemaining, "487");

            HttpClient client = ClientTestHelpers.CreateHttpClient((_, _) =>
                Task.FromResult(tooManyRequestsResponse));

            Result<WalletApiGetExecutorTestResponse> result = await WalletApiGetExecutor.ExecuteAsync<
                WalletApiGetExecutorTestRequest,
                WalletApiGetExecutorTestRequestDto,
                WalletApiGetExecutorTestResponseDto,
                WalletApiGetExecutorTestResponse>(
                client,
                "/endpoint",
                new WalletApiGetExecutorTestRequest(),
                new DelegateMapper<WalletApiGetExecutorTestRequest, WalletApiGetExecutorTestRequestDto>(_ => new WalletApiGetExecutorTestRequestDto()),
                new DelegateMapper<WalletApiGetExecutorTestResponseDto, WalletApiGetExecutorTestResponse>(_ => new WalletApiGetExecutorTestResponse()),
                CancellationToken.None);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(result.IsFailed, Is.True);
                Assert.That(result.Errors[0].Metadata[ApiConstant.Metadata.StatusCode], Is.EqualTo((int)HttpStatusCode.TooManyRequests));
                Assert.That(result.Errors[0].Metadata[ApiConstant.Metadata.RetryAfter], Is.EqualTo(60));
                Assert.That(result.Errors[0].Metadata[ApiConstant.Metadata.RateLimitLimit], Is.EqualTo(500));
                Assert.That(result.Errors[0].Metadata[ApiConstant.Metadata.RateLimitRemaining], Is.EqualTo(487));
            }
        }

        [Test]
        public async Task ExecuteAsync_WhenApiReturnsNonSuccessAndReasonPhraseIsNull_UsesEmptyReasonPhraseMetadata()
        {
            HttpResponseMessage responseMessage = new HttpResponseMessage((HttpStatusCode)499)
            {
                Content = new StringContent("{\"error\":\"bad\"}", Encoding.UTF8, "application/json"),
                ReasonPhrase = null
            };

            HttpClient client = ClientTestHelpers.CreateHttpClient((_, _) =>
                Task.FromResult(responseMessage));

            Result<WalletApiGetExecutorTestResponse> result = await WalletApiGetExecutor.ExecuteAsync<
                WalletApiGetExecutorTestRequest,
                WalletApiGetExecutorTestRequestDto,
                WalletApiGetExecutorTestResponseDto,
                WalletApiGetExecutorTestResponse>(
                client,
                "/endpoint",
                new WalletApiGetExecutorTestRequest(),
                new DelegateMapper<WalletApiGetExecutorTestRequest, WalletApiGetExecutorTestRequestDto>(_ => new WalletApiGetExecutorTestRequestDto()),
                new DelegateMapper<WalletApiGetExecutorTestResponseDto, WalletApiGetExecutorTestResponse>(_ => new WalletApiGetExecutorTestResponse()),
                CancellationToken.None);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(result.IsFailed, Is.True);
                Assert.That(result.Errors[0].Metadata[ApiConstant.Metadata.StatusCode], Is.EqualTo(499));
                Assert.That(result.Errors[0].Metadata[ApiConstant.Metadata.ReasonPhrase], Is.EqualTo(string.Empty));
            }
        }
    }
}
