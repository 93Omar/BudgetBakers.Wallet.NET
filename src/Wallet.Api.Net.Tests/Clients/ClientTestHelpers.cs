using System.Net.Http.Headers;
using System.Text;
using Wallet.Api.Net.Tests.Infrastructure;

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
    }
}
