using System.Globalization;
using BudgetBakers.Wallet.Net.Constants;
using BudgetBakers.Wallet.Net.Models.ResponseInfo;
using BudgetBakers.Wallet.Net.Utility;

namespace BudgetBakers.Wallet.Net.Services.Clients
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
