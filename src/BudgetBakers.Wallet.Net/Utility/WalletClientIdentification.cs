using System.Net.Http;
using BudgetBakers.Wallet.Net.Constants;

namespace BudgetBakers.Wallet.Net.Utility
{
    internal static class WalletClientIdentification
    {
        // No version on purpose: the release version is driven by the publish pipeline tag, so keeping it here
        // would mean two sources of truth.
        private static readonly string UserAgentValue =
            $"{ApiConstant.Client.Name} (+{ApiConstant.Client.ProjectUrl})";

        internal static void ApplyUserAgent(HttpClient client)
        {
            client.DefaultRequestHeaders.UserAgent.ParseAdd(UserAgentValue);
        }
    }
}
