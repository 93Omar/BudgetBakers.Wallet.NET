using System.Net;
using System.Text;
using BudgetBakers.Wallet.Net.Services;
using BudgetBakers.Wallet.Net.Tests.Infrastructure;
using Microsoft.Extensions.Logging;

namespace BudgetBakers.Wallet.Net.Tests.Services
{
    public class LoggingDelegatingHandlerTests
    {
        private const string RequestUri = "https://localhost/wallet/accounts";
        private const string ResponseBody = """{"items":[]}""";

        [Test]
        public async Task SendAsync_WhenTraceLevelEnabled_LogsRequestUriAndResponseBody()
        {
            var logger = new TestLogger<LoggingDelegatingHandler>(LogLevel.Trace);
            var handler = CreateHandler(logger, HttpStatusCode.OK, ResponseBody);
            using var invoker = new HttpMessageInvoker(handler);
            using var request = new HttpRequestMessage(HttpMethod.Get, RequestUri);

            _ = await invoker.SendAsync(request, CancellationToken.None);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(logger.Logs, Has.Count.EqualTo(2));
                Assert.That(logger.Logs[0].Level, Is.EqualTo(LogLevel.Trace));
                Assert.That(logger.Logs[0].Message, Does.Contain(RequestUri));
                Assert.That(logger.Logs[1].Level, Is.EqualTo(LogLevel.Trace));
                Assert.That(logger.Logs[1].Message, Does.Contain(ResponseBody));
                Assert.That(logger.Logs[1].Message, Does.Contain("200"));
            }
        }

        [Test]
        public async Task SendAsync_WhenTraceLevelDisabled_ProducesNoLogEntries()
        {
            var logger = new TestLogger<LoggingDelegatingHandler>(LogLevel.None);
            var handler = CreateHandler(logger, HttpStatusCode.OK, ResponseBody);
            using var invoker = new HttpMessageInvoker(handler);
            using var request = new HttpRequestMessage(HttpMethod.Get, RequestUri);

            _ = await invoker.SendAsync(request, CancellationToken.None);

            Assert.That(logger.Logs, Is.Empty);
        }

        [Test]
        public async Task SendAsync_WhenTraceLevelDisabled_DoesNotBufferResponseContent()
        {
            var logger = new TestLogger<LoggingDelegatingHandler>(LogLevel.None);
            var trackingContent = new TrackingStreamContent(ResponseBody);

            var innerHandler = new DelegateHttpMessageHandler((_, _) =>
                Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK) { Content = trackingContent }));

            var handler = new LoggingDelegatingHandler(logger) { InnerHandler = innerHandler };
            using var invoker = new HttpMessageInvoker(handler);
            using var request = new HttpRequestMessage(HttpMethod.Get, RequestUri);

            _ = await invoker.SendAsync(request, CancellationToken.None);

            Assert.That(trackingContent.WasRead, Is.False);
        }

        [Test]
        public async Task SendAsync_WhenTraceLevelEnabled_ResponseCanStillBeReadByExecutor()
        {
            var logger = new TestLogger<LoggingDelegatingHandler>(LogLevel.Trace);
            var handler = CreateHandler(logger, HttpStatusCode.OK, ResponseBody);
            using var invoker = new HttpMessageInvoker(handler);
            using var request = new HttpRequestMessage(HttpMethod.Get, RequestUri);

            using HttpResponseMessage response = await invoker.SendAsync(request, CancellationToken.None);
            string bodyReadByExecutor = await response.Content.ReadAsStringAsync();

            Assert.That(bodyReadByExecutor, Is.EqualTo(ResponseBody));
        }

        [Test]
        public async Task SendAsync_WhenResponseIsError_LogsStatusCodeAndBody()
        {
            const string errorBody = """{"error":"unauthorized"}""";
            var logger = new TestLogger<LoggingDelegatingHandler>(LogLevel.Trace);
            var handler = CreateHandler(logger, HttpStatusCode.Unauthorized, errorBody);
            using var invoker = new HttpMessageInvoker(handler);
            using var request = new HttpRequestMessage(HttpMethod.Get, RequestUri);

            _ = await invoker.SendAsync(request, CancellationToken.None);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(logger.Logs, Has.Count.EqualTo(2));
                Assert.That(logger.Logs[1].Message, Does.Contain("401"));
                Assert.That(logger.Logs[1].Message, Does.Contain(errorBody));
            }
        }

        [Test]
        public async Task SendAsync_WhenTraceLevelEnabledAndRequestHasBody_LogsRequestBody()
        {
            const string requestBody = """{"name":"test"}""";
            var logger = new TestLogger<LoggingDelegatingHandler>(LogLevel.Trace);
            var handler = CreateHandler(logger, HttpStatusCode.OK, ResponseBody);
            using var invoker = new HttpMessageInvoker(handler);
            using var request = new HttpRequestMessage(HttpMethod.Post, RequestUri)
            {
                Content = new StringContent(requestBody, Encoding.UTF8, "application/json")
            };

            _ = await invoker.SendAsync(request, CancellationToken.None);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(logger.Logs, Has.Count.EqualTo(2));
                Assert.That(logger.Logs[0].Message, Does.Contain(requestBody));
            }
        }

        [Test]
        public async Task SendAsync_WhenTraceLevelEnabledAndRequestHasBody_RequestBodyCanStillBeSentByExecutor()
        {
            const string requestBody = """{"name":"test"}""";
            var logger = new TestLogger<LoggingDelegatingHandler>(LogLevel.Trace);
            string? capturedBody = null;

            var innerHandler = new DelegateHttpMessageHandler(async (req, _) =>
            {
                capturedBody = await req.Content!.ReadAsStringAsync();
                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(ResponseBody, Encoding.UTF8, "application/json")
                };
            });

            var handler = new LoggingDelegatingHandler(logger) { InnerHandler = innerHandler };
            using var invoker = new HttpMessageInvoker(handler);
            using var request = new HttpRequestMessage(HttpMethod.Post, RequestUri)
            {
                Content = new StringContent(requestBody, Encoding.UTF8, "application/json")
            };

            _ = await invoker.SendAsync(request, CancellationToken.None);

            Assert.That(capturedBody, Is.EqualTo(requestBody));
        }

        [Test]
        public async Task SendAsync_WhenTraceLevelEnabledAndNoRequestBody_LogsOnlyMethodAndUri()
        {
            var logger = new TestLogger<LoggingDelegatingHandler>(LogLevel.Trace);
            var handler = CreateHandler(logger, HttpStatusCode.OK, ResponseBody);
            using var invoker = new HttpMessageInvoker(handler);
            using var request = new HttpRequestMessage(HttpMethod.Get, RequestUri);

            _ = await invoker.SendAsync(request, CancellationToken.None);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(logger.Logs[0].Message, Does.Contain(RequestUri));
                Assert.That(logger.Logs[0].Message, Does.Not.Contain("Body"));
            }
        }

        [Test]
        public async Task SendAsync_WhenCancellationTokenProvided_PassesItThrough()
        {
            var logger = new TestLogger<LoggingDelegatingHandler>(LogLevel.None);
            CancellationToken capturedToken = default;

            var innerHandler = new DelegateHttpMessageHandler((_, ct) =>
            {
                capturedToken = ct;
                return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(ResponseBody)
                });
            });

            var handler = new LoggingDelegatingHandler(logger) { InnerHandler = innerHandler };
            using var invoker = new HttpMessageInvoker(handler);
            using var request = new HttpRequestMessage(HttpMethod.Get, RequestUri);
            using var cts = new CancellationTokenSource();

            _ = await invoker.SendAsync(request, cts.Token);

            Assert.That(capturedToken, Is.EqualTo(cts.Token));
        }

        private static LoggingDelegatingHandler CreateHandler(
            TestLogger<LoggingDelegatingHandler> logger,
            HttpStatusCode statusCode,
            string body)
        {
            var innerHandler = new DelegateHttpMessageHandler((_, _) =>
                Task.FromResult(new HttpResponseMessage(statusCode)
                {
                    Content = new StringContent(body, Encoding.UTF8, "application/json")
                }));

            return new LoggingDelegatingHandler(logger) { InnerHandler = innerHandler };
        }

        private sealed class TrackingStreamContent(string content) : HttpContent
        {
            public bool WasRead { get; private set; }

            protected override async Task SerializeToStreamAsync(Stream stream, TransportContext? context)
            {
                WasRead = true;
                await stream.WriteAsync(Encoding.UTF8.GetBytes(content));
            }

            protected override bool TryComputeLength(out long length)
            {
                length = Encoding.UTF8.GetByteCount(content);
                return true;
            }
        }
    }
}
