using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetBakers.Wallet.Net.Constants
{
    internal static class ApiConstant
    {
        internal const string DefaultBaseAddress = "https://rest.budgetbakers.com/wallet/";

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
            internal const string Filters = ",";
        }

        internal static class Endpoint
        {
            internal const string Accounts = "v1/api/accounts";
            internal const string Budgets = "v1/api/budgets";
            internal const string Categories = "v1/api/categories";
            internal const string CategoriesCustom = "v1/api/categories/custom";
            internal const string Goals = "v1/api/goals";
            internal const string Labels = "v1/api/labels";
            internal const string Records = "v1/api/records";
            internal const string RecordRules = "v1/api/record-rules";
            internal const string StandingOrders = "v1/api/standing-orders";
            internal const string StandingOrderItems = "v1/api/standing-orders/items";
            internal const string Stats = "v1/api/api-usage/stats";
            internal const string DeleteTemplate = "v1/api/{0}";
            internal const string ReferencesTemplate = "v1/api/{0}/references";
        }
    }
}
