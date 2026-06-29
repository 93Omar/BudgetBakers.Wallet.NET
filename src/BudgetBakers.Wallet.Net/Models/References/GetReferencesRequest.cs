using System;
using System.Collections.Generic;
using BudgetBakers.Wallet.Net.Models.References;
using BudgetBakers.Wallet.Net.Models.ResponseInfo;

namespace BudgetBakers.Wallet.Net.Models.References
{
    public class GetReferencesRequest
    {
        /// <summary>
        /// Entity type to look up references for.
        /// </summary>
        public required ReferenceEntityType EntityType { get; set; }

        /// <summary>
        /// IDs to check references for (max 10).
        /// </summary>
        public IList<string> Ids { get; set; } = [];
    }
}
