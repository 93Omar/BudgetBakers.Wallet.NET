using System;
using System.Collections.Generic;
using System.Text;

namespace Wallet.Api.Net.Constants
{
    internal static class ApiConstant
    {
        internal static class Message
        {
            internal const string NullRequest = "Request cannot be null.";
            internal const string ApiNonSuccess = "Wallet API returned a non-success status code.";
            internal const string EmptyResponseBody = "Wallet API returned an empty response body.";
        }

        internal static class Metadata
        {
            internal const string Endpoint = "Endpoint";
            internal const string StatusCode = "StatusCode";
            internal const string ReasonPhrase = "ReasonPhrase";
            internal const string ResponseBody = "ResponseBody";
            internal const string RateLimitLimit = "RateLimitLimit";
            internal const string RateLimitRemaining = "RateLimitRemaining";
            internal const string RetryAfter = "RetryAfter";
        }

        internal static class Header
        {
            internal const string RateLimitLimit = "X-RateLimit-Limit";
            internal const string RateLimitRemaining = "X-RateLimit-Remaining";
            internal const string RetryAfter = "Retry-After";
            internal const string LastDataChangeAt = "X-Last-Data-Change-At";
            internal const string LastDataChangeRevision = "X-Last-Data-Change-Rev";
            internal const string SyncInProgress = "X-Sync-In-Progress";
        }

        internal static class Separator
        {
            internal const string Ids = ",";
        }
    }
}
