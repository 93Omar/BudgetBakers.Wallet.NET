using System.Net.Http.Headers;

namespace Wallet.Api.Net.Services
{
    public class BearerTokenDelegatingHandler : DelegatingHandler
    {
        private readonly IAccessTokenProvider _tokenProvider;

        public BearerTokenDelegatingHandler(IAccessTokenProvider tokenProvider)
        {
            _tokenProvider = tokenProvider;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            string accessToken = await _tokenProvider.GetAccessTokenAsync(cancellationToken);

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            return await base.SendAsync(request, cancellationToken);
        }
    }
}
