using System.Collections.Generic;
using BudgetBakers.Wallet.Net.Models.ResponseInfo;

namespace BudgetBakers.Wallet.Net.Models.References
{
    public class GetReferencesResponse : IRateLimitResponse
    {
        public RateLimitInfo RateLimit { get; set; } = new RateLimitInfo();

        /// <summary>
        /// Map from input entity ID to its cross-reference results.
        /// </summary>
        public IReadOnlyDictionary<string, EntityReferences> References { get; set; } = new Dictionary<string, EntityReferences>();
    }
}
