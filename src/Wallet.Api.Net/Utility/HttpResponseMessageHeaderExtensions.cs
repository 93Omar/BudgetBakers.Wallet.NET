using System.Globalization;

namespace Wallet.Api.Net.Utility
{
    internal static class HttpResponseMessageHeaderExtensions
    {
        public static string? TryGetHeaderValue(this HttpResponseMessage responseMessage, string headerName)
        {
            if (responseMessage.Headers.TryGetValues(headerName, out IEnumerable<string>? values))
                return values.FirstOrDefault();

            return null;
        }

        public static int? TryGetIntHeaderValue(this HttpResponseMessage responseMessage, string headerName)
        {
            string? headerValue = responseMessage.TryGetHeaderValue(headerName);

            if (int.TryParse(headerValue, NumberStyles.Integer, CultureInfo.InvariantCulture, out int parsedHeaderValue))
                return parsedHeaderValue;

            return null;
        }
    }
}
