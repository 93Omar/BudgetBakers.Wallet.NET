using System.Net;
using System.Text;
using System.Text.Json;
using Wallet.Api.Net.Models.Record;
using Wallet.Api.Net.Services.Clients;

namespace Wallet.Api.Net.Tests.Clients
{
    public class RecordClientTests
    {
        private static readonly string[] SingleRecordId = ["id-1"];

        [Test]
        public async Task GetAsync_WhenResponseIsSuccessful_ReturnsSuccess()
        {
            var client = new RecordClient(ClientTestHelpers.CreateHttpClient((request, _) =>
                Task.FromResult(request.RequestUri!.AbsolutePath.EndsWith("/by-id", StringComparison.Ordinal)
                    ? new HttpResponseMessage(HttpStatusCode.OK)
                    {
                        Content = ClientTestHelpers.CreateJsonContent("""
                        {
                          "count": 0,
                          "records": [],
                          "agentHints": []
                        }
                        """)
                    }
                    : new HttpResponseMessage(HttpStatusCode.OK)
                    {
                        Content = ClientTestHelpers.CreateJsonContent("""
                        {
                          "limit": 10,
                          "offset": 0,
                          "nextOffset": 0,
                          "recordDateRange": [],
                          "records": [],
                          "agentHints": []
                        }
                        """)
                    })));

            var result = await client.GetAsync(new GetRecordsRequest { Limit = 10, Offset = 0 });

            using (Assert.EnterMultipleScope())
            {
                Assert.That(result.IsSuccess, Is.True);
                Assert.That(result.Value, Is.Not.Null);
            }
        }

        [Test]
        public async Task GetByIdAsync_WhenResponseIsSuccessful_ReturnsSuccess()
        {
            var client = new RecordClient(ClientTestHelpers.CreateHttpClient((request, _) =>
                Task.FromResult(request.RequestUri!.AbsolutePath.EndsWith("/by-id", StringComparison.Ordinal)
                    ? new HttpResponseMessage(HttpStatusCode.OK)
                    {
                        Content = ClientTestHelpers.CreateJsonContent("""
                        {
                          "count": 0,
                          "records": [],
                          "agentHints": []
                        }
                        """)
                    }
                    : new HttpResponseMessage(HttpStatusCode.OK)
                    {
                        Content = ClientTestHelpers.CreateJsonContent("""
                        {
                          "limit": 10,
                          "offset": 0,
                          "nextOffset": 0,
                          "recordDateRange": [],
                          "records": [],
                          "agentHints": []
                        }
                        """)
                    })));

            var result = await client.GetByIdAsync(new GetRecordsByIdRequest { Ids = SingleRecordId });

            using (Assert.EnterMultipleScope())
            {
                Assert.That(result.IsSuccess, Is.True);
                Assert.That(result.Value, Is.Not.Null);
            }
        }

        [Test]
        public async Task GetAsync_WhenRequestIsNull_ReturnsFailedResult()
        {
            var client = new RecordClient(ClientTestHelpers.CreateHttpClient((_, _) =>
                throw new InvalidOperationException("HTTP should not be called for null request")));

            var result = await client.GetAsync(null!);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(result.IsFailed, Is.True);
                Assert.That(result.Errors, Is.Not.Empty);
            }
        }

        [Test]
        public async Task GetByIdAsync_WhenRequestIsNull_ReturnsFailedResult()
        {
            var client = new RecordClient(ClientTestHelpers.CreateHttpClient((_, _) =>
                throw new InvalidOperationException("HTTP should not be called for null request")));

            var result = await client.GetByIdAsync(null!);

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
            var client = new RecordClient(ClientTestHelpers.CreateHttpClient((_, _) =>
                Task.FromResult(new HttpResponseMessage(statusCode)
                {
                    Content = new StringContent("{\"error\":\"generic\"}", Encoding.UTF8, "application/json")
                })));

            var result = await client.GetAsync(new GetRecordsRequest { Limit = 1, Offset = 0 });

            using (Assert.EnterMultipleScope())
            {
                Assert.That(result.IsFailed, Is.True);
                Assert.That(result.Errors, Is.Not.Empty);
                Assert.That(result.Errors[0].Metadata["StatusCode"], Is.EqualTo((int)statusCode));
            }
        }

        [TestCase(HttpStatusCode.BadRequest)]
        [TestCase(HttpStatusCode.Unauthorized)]
        [TestCase(HttpStatusCode.InternalServerError)]
        public async Task GetByIdAsync_WhenApiReturnsNonSuccessStatus_PropagatesStatusCodeInErrorMetadata(HttpStatusCode statusCode)
        {
            var client = new RecordClient(ClientTestHelpers.CreateHttpClient((_, _) =>
                Task.FromResult(new HttpResponseMessage(statusCode)
                {
                    Content = new StringContent("{\"error\":\"generic\"}", Encoding.UTF8, "application/json")
                })));

            var result = await client.GetByIdAsync(new GetRecordsByIdRequest { Ids = SingleRecordId });

            using (Assert.EnterMultipleScope())
            {
                Assert.That(result.IsFailed, Is.True);
                Assert.That(result.Errors, Is.Not.Empty);
                Assert.That(result.Errors[0].Metadata["StatusCode"], Is.EqualTo((int)statusCode));
            }
        }

        [Test]
        public async Task GetAsync_WhenApiReturnsNullJson_ReturnsFailedResult()
        {
            var client = new RecordClient(ClientTestHelpers.CreateHttpClient((_, _) =>
                Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = ClientTestHelpers.CreateJsonContent("null")
                })));

            var result = await client.GetAsync(new GetRecordsRequest { Limit = 1, Offset = 0 });

            using (Assert.EnterMultipleScope())
            {
                Assert.That(result.IsFailed, Is.True);
                Assert.That(result.Errors, Is.Not.Empty);
            }
        }

        [Test]
        public async Task GetByIdAsync_WhenApiReturnsNullJson_ReturnsFailedResult()
        {
            var client = new RecordClient(ClientTestHelpers.CreateHttpClient((_, _) =>
                Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = ClientTestHelpers.CreateJsonContent("null")
                })));

            var result = await client.GetByIdAsync(new GetRecordsByIdRequest { Ids = SingleRecordId });

            using (Assert.EnterMultipleScope())
            {
                Assert.That(result.IsFailed, Is.True);
                Assert.That(result.Errors, Is.Not.Empty);
            }
        }

        [Test]
        public void GetAsync_WhenApiReturnsInvalidJson_ThrowsJsonException()
        {
            var client = new RecordClient(ClientTestHelpers.CreateHttpClient((_, _) =>
                Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = ClientTestHelpers.CreateJsonContent("{ invalid json")
                })));

            Assert.That(async () => await client.GetAsync(new GetRecordsRequest { Limit = 1, Offset = 0 }), Throws.TypeOf<JsonException>());
        }

        [Test]
        public void GetByIdAsync_WhenApiReturnsInvalidJson_ThrowsJsonException()
        {
            var client = new RecordClient(ClientTestHelpers.CreateHttpClient((_, _) =>
                Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = ClientTestHelpers.CreateJsonContent("{ invalid json")
                })));

            Assert.That(async () => await client.GetByIdAsync(new GetRecordsByIdRequest { Ids = SingleRecordId }), Throws.TypeOf<JsonException>());
        }
    }
}
