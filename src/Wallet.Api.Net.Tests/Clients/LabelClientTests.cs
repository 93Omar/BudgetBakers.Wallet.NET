using System.Net;
using System.Text;
using System.Text.Json;
using FluentResults;
using Wallet.Api.Net.Constants;
using Wallet.Api.Net.Models.Label;
using Wallet.Api.Net.Services.Clients;

namespace Wallet.Api.Net.Tests.Clients
{
    public class LabelClientTests
    {
        [Test]
        public async Task GetAsync_WhenResponseIsSuccessful_ReturnsSuccess()
        {
            var client = new LabelClient(ClientTestHelpers.CreateHttpClient((_, _) =>
                Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = ClientTestHelpers.CreateJsonContent("""
                    {
                      "limit": 10,
                      "offset": 0,
                      "nextOffset": 0,
                      "labels": [],
                      "agentHints": []
                    }
                    """)
                })));

            Result<GetLabelsResponse> result = await client.GetAsync(new GetLabelsRequest { Limit = 10, Offset = 0 });

            using (Assert.EnterMultipleScope())
            {
                Assert.That(result.IsSuccess, Is.True);
                Assert.That(result.Value, Is.Not.Null);
            }
        }

        [Test]
        public async Task GetAsync_WhenRequestIsNull_ReturnsFailedResult()
        {
            var client = new LabelClient(ClientTestHelpers.CreateHttpClient((_, _) =>
                throw new InvalidOperationException("HTTP should not be called for null request")));

            Result<GetLabelsResponse> result = await client.GetAsync(null!);

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
            var client = new LabelClient(ClientTestHelpers.CreateHttpClient((_, _) =>
                Task.FromResult(new HttpResponseMessage(statusCode)
                {
                    Content = new StringContent("{\"error\":\"generic\"}", Encoding.UTF8, "application/json")
                })));

            Result<GetLabelsResponse> result = await client.GetAsync(new GetLabelsRequest { Limit = 1, Offset = 0 });

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
            var client = new LabelClient(ClientTestHelpers.CreateHttpClient((_, _) =>
                Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = ClientTestHelpers.CreateJsonContent("null")
                })));

            Result<GetLabelsResponse> result = await client.GetAsync(new GetLabelsRequest { Limit = 1, Offset = 0 });

            using (Assert.EnterMultipleScope())
            {
                Assert.That(result.IsFailed, Is.True);
                Assert.That(result.Errors, Is.Not.Empty);
            }
        }

        [Test]
        public void GetAsync_WhenApiReturnsInvalidJson_ThrowsJsonException()
        {
            var client = new LabelClient(ClientTestHelpers.CreateHttpClient((_, _) =>
                Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = ClientTestHelpers.CreateJsonContent("{ invalid json")
                })));

            Assert.That(async () => await client.GetAsync(new GetLabelsRequest { Limit = 1, Offset = 0 }), Throws.TypeOf<JsonException>());
        }
    }
}
