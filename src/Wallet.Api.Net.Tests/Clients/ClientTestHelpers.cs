using System.Net.Http.Headers;
using System.Text;

namespace Wallet.Api.Net.Tests.Clients
{
    internal static class ClientTestHelpers
    {
        internal static HttpClient CreateHttpClient(Func<HttpRequestMessage, CancellationToken, Task<HttpResponseMessage>> responder)
            => new(new DelegateHttpMessageHandler(responder))
            {
                BaseAddress = new Uri("https://localhost")
            };

        internal static StringContent CreateJsonContent(string json)
        {
            var content = new StringContent(json, Encoding.UTF8);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return content;
        }

        private sealed class DelegateHttpMessageHandler : HttpMessageHandler
        {
            private readonly Func<HttpRequestMessage, CancellationToken, Task<HttpResponseMessage>> _responder;

            public DelegateHttpMessageHandler(Func<HttpRequestMessage, CancellationToken, Task<HttpResponseMessage>> responder)
            {
                _responder = responder;
            }

            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
                => _responder(request, cancellationToken);
        }
    }
}
