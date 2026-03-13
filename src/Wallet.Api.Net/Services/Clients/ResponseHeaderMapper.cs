using System.Globalization;
using Wallet.Api.Net.Constants;
using Wallet.Api.Net.Models.ResponseInfo;
using Wallet.Api.Net.Utility;

namespace Wallet.Api.Net.Services.Clients
{
    internal static class ResponseHeaderMapper
    {
        public static void Apply<TResponse>(HttpResponseMessage responseMessage, TResponse response)
            where TResponse : class
        {
            if (response is IRateLimitResponse rateLimitResponse)
                MapRateLimitValues(responseMessage, rateLimitResponse.RateLimit);

            if (response is IDataSynchronizationResponse dataSynchronizationResponse)
                MapDataSynchronizationValues(responseMessage, dataSynchronizationResponse.DataSynchronization);
        }

        private static void MapRateLimitValues(HttpResponseMessage responseMessage, RateLimitInfo rateLimitInfo)
        {
            rateLimitInfo.Limit = responseMessage.TryGetIntHeaderValue(ApiConstant.Header.RateLimitLimit);
            rateLimitInfo.Remaining = responseMessage.TryGetIntHeaderValue(ApiConstant.Header.RateLimitRemaining);
            rateLimitInfo.RetryAfter = responseMessage.TryGetIntHeaderValue(ApiConstant.Header.RetryAfter);
        }

        private static void MapDataSynchronizationValues(HttpResponseMessage responseMessage, DataSynchronizationInfo dataSynchronizationInfo)
        {
            string? lastDataChangeAt = responseMessage.TryGetHeaderValue(ApiConstant.Header.LastDataChangeAt);
            if (DateTime.TryParse(lastDataChangeAt, CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal | DateTimeStyles.AdjustToUniversal, out DateTime parsedLastDataChangeAt))
                dataSynchronizationInfo.LastDataChangeAt = parsedLastDataChangeAt;

            dataSynchronizationInfo.LastDataChangeRevision = responseMessage.TryGetHeaderValue(ApiConstant.Header.LastDataChangeRevision);

            string? syncInProgress = responseMessage.TryGetHeaderValue(ApiConstant.Header.SyncInProgress);
            if (bool.TryParse(syncInProgress, out bool parsedSyncInProgress))
                dataSynchronizationInfo.SyncInProgress = parsedSyncInProgress;
        }
    }
}
