using Microsoft.Extensions.Logging;

namespace BudgetBakers.Wallet.Net.Services
{
    internal sealed class LoggingDelegatingHandler(ILogger<LoggingDelegatingHandler> logger) : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (logger.IsEnabled(LogLevel.Trace))
            {
                if (request.Content is not null)
                {
#if NET9_0_OR_GREATER
                    await request.Content.LoadIntoBufferAsync(cancellationToken);
#else
                    await request.Content.LoadIntoBufferAsync();
#endif
                    string requestBody = await request.Content.ReadAsStringAsync(cancellationToken);
                    logger.LogTrace("Wallet API → {Method} {Uri} {Body}", request.Method, request.RequestUri, requestBody);
                }
                else
                {
                    logger.LogTrace("Wallet API → {Method} {Uri}", request.Method, request.RequestUri);
                }
            }

            HttpResponseMessage response = await base.SendAsync(request, cancellationToken);

            if (logger.IsEnabled(LogLevel.Trace))
            {
#if NET9_0_OR_GREATER
                await response.Content.LoadIntoBufferAsync(cancellationToken);
#else
                await response.Content.LoadIntoBufferAsync();
#endif
                string responseBody = await response.Content.ReadAsStringAsync(cancellationToken);
                logger.LogTrace("Wallet API ← {StatusCode} {Body}", (int)response.StatusCode, responseBody);
            }

            return response;
        }
    }
}
