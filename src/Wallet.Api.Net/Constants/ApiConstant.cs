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
        }

        internal static class Separator
        {
            internal const string Ids = ",";
        }
    }
}
