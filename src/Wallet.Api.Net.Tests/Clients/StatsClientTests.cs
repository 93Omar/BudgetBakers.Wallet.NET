using System.Net;
using System.Text;
using System.Text.Json;
using FluentResults;
using Wallet.Api.Net.Constants;
using Wallet.Api.Net.Models;
using Wallet.Api.Net.Models.Stats;
using Wallet.Api.Net.Services.Clients;

namespace Wallet.Api.Net.Tests.Clients
{
    public class StatsClientTests
    {
        [Test]
        public async Task GetAsync_WhenResponseIsSuccessful_ReturnsSuccess()
        {
            StatsClient client = new(ClientTestHelpers.CreateHttpClient((_, _) =>
                Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = ClientTestHelpers.CreateJsonContent("""
                    {
                      "granularity": "daily",
                      "period": "30days",
                      "total": 150,
                      "usage": []
                    }
                    """)
                })));

            GetStatsRequest request = new()
            {
                Period = new PeriodFilter
                {
                    Prefix = PeriodPrefix.Days,
                    Value = 30
                }
            };

            Result<GetStatsResponse> result = await client.GetAsync(request);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(result.IsSuccess, Is.True);
                Assert.That(result.Value, Is.Not.Null);
            }
        }

        [Test]
        public async Task GetAsync_WhenRequestIsNull_ReturnsFailedResult()
        {
            StatsClient client = new(ClientTestHelpers.CreateHttpClient((_, _) =>
                throw new InvalidOperationException("HTTP should not be called for null request")));

            Result<GetStatsResponse> result = await client.GetAsync(null!);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(result.IsFailed, Is.True);
                Assert.That(result.Errors, Is.Not.Empty);
            }
        }

        [TestCase(HttpStatusCode.BadRequest)]
        [TestCase(HttpStatusCode.Unauthorized)]
        [TestCase(HttpStatusCode.InternalServerError)]
        public async Task GetAsync_WhenApiReturnsNonSuccessStatus_PropagatesStatusCodeInErrorMetadata(HttpStatusCode statusCode)
        {
            StatsClient client = new(ClientTestHelpers.CreateHttpClient((_, _) =>
                Task.FromResult(new HttpResponseMessage(statusCode)
                {
                    Content = new StringContent("{\"error\":\"generic\"}", Encoding.UTF8, "application/json")
                })));

            GetStatsRequest request = new()
            {
                Period = new PeriodFilter
                {
                    Prefix = PeriodPrefix.Days,
                    Value = 30
                }
            };

            Result<GetStatsResponse> result = await client.GetAsync(request);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(result.IsFailed, Is.True);
                Assert.That(result.Errors, Is.Not.Empty);
                Assert.That(result.Errors[0].Metadata[ApiConstant.Metadata.StatusCode], Is.EqualTo((int)statusCode));
            }
        }

        [Test]
        public async Task GetAsync_WhenApiReturnsNullJson_ReturnsFailedResult()
        {
            StatsClient client = new(ClientTestHelpers.CreateHttpClient((_, _) =>
                Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = ClientTestHelpers.CreateJsonContent("null")
                })));

            GetStatsRequest request = new()
            {
                Period = new PeriodFilter
                {
                    Prefix = PeriodPrefix.Days,
                    Value = 30
                }
            };

            Result<GetStatsResponse> result = await client.GetAsync(request);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(result.IsFailed, Is.True);
                Assert.That(result.Errors, Is.Not.Empty);
            }
        }

        [Test]
        public void GetAsync_WhenApiReturnsInvalidJson_ThrowsJsonException()
        {
            StatsClient client = new(ClientTestHelpers.CreateHttpClient((_, _) =>
                Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = ClientTestHelpers.CreateJsonContent("{ invalid json")
                })));

            GetStatsRequest request = new()
            {
                Period = new PeriodFilter
                {
                    Prefix = PeriodPrefix.Days,
                    Value = 30
                }
            };

            Assert.That(async () => await client.GetAsync(request), Throws.TypeOf<JsonException>());
        }
    }
}
