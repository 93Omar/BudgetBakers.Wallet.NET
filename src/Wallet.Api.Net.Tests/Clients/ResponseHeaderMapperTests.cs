using System.Net;
using Wallet.Api.Net.Constants;
using Wallet.Api.Net.Services.Clients;
using Wallet.Api.Net.Tests.Infrastructure;

namespace Wallet.Api.Net.Tests.Clients
{
    public class ResponseHeaderMapperTests
    {
        [Test]
        public void Apply_WhenResponseImplementsInterfaces_MapsAllSupportedHeaders()
        {
            HttpResponseMessage responseMessage = new HttpResponseMessage(HttpStatusCode.OK);
            responseMessage.Headers.Add(ApiConstant.Header.RateLimitLimit, "500");
            responseMessage.Headers.Add(ApiConstant.Header.RateLimitRemaining, "487");
            responseMessage.Headers.Add(ApiConstant.Header.RetryAfter, "60");
            responseMessage.Headers.Add(ApiConstant.Header.LastDataChangeAt, "2024-01-28T14:23:45.123Z");
            responseMessage.Headers.Add(ApiConstant.Header.LastDataChangeRevision, "r1234");
            responseMessage.Headers.Add(ApiConstant.Header.SyncInProgress, "false");

            ResponseHeaderMapperTestResponse response = new ResponseHeaderMapperTestResponse();

            ResponseHeaderMapper.Apply(responseMessage, response);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(response.RateLimit.Limit, Is.EqualTo(500));
                Assert.That(response.RateLimit.Remaining, Is.EqualTo(487));
                Assert.That(response.RateLimit.RetryAfter, Is.EqualTo(60));
                Assert.That(response.DataSynchronization.LastDataChangeAt, Is.EqualTo(DateTime.Parse("2024-01-28T14:23:45.123Z").ToUniversalTime()));
                Assert.That(response.DataSynchronization.LastDataChangeRevision, Is.EqualTo("r1234"));
                Assert.That(response.DataSynchronization.SyncInProgress, Is.False);
            }
        }

        [Test]
        public void Apply_WhenHeaderValuesAreInvalid_LeavesParsedFieldsAsNull()
        {
            HttpResponseMessage responseMessage = new HttpResponseMessage(HttpStatusCode.OK);
            responseMessage.Headers.Add(ApiConstant.Header.RateLimitLimit, "invalid");
            responseMessage.Headers.Add(ApiConstant.Header.RateLimitRemaining, "not-a-number");
            responseMessage.Headers.Add(ApiConstant.Header.LastDataChangeAt, "not-a-date");
            responseMessage.Headers.Add(ApiConstant.Header.SyncInProgress, "not-a-bool");

            ResponseHeaderMapperTestResponse response = new ResponseHeaderMapperTestResponse();

            ResponseHeaderMapper.Apply(responseMessage, response);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(response.RateLimit.Limit, Is.Null);
                Assert.That(response.RateLimit.Remaining, Is.Null);
                Assert.That(response.RateLimit.RetryAfter, Is.Null);
                Assert.That(response.DataSynchronization.LastDataChangeAt, Is.Null);
                Assert.That(response.DataSynchronization.SyncInProgress, Is.Null);
                Assert.That(response.DataSynchronization.LastDataChangeRevision, Is.Null);
            }
        }

        [Test]
        public void Apply_WhenResponseDoesNotImplementInterfaces_DoesNotThrow()
        {
            HttpResponseMessage responseMessage = new HttpResponseMessage(HttpStatusCode.OK);
            ResponseHeaderMapperUnsupportedResponse response = new ResponseHeaderMapperUnsupportedResponse();

            Assert.DoesNotThrow(() => ResponseHeaderMapper.Apply(responseMessage, response));
        }
    }
}
