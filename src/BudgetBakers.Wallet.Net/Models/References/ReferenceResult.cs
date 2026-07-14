using System.Collections.Generic;

namespace BudgetBakers.Wallet.Net.Models.References
{
    public class ReferenceResult
    {
        /// <summary>
        /// Field name used for the reference.
        /// </summary>
        public string? Field { get; set; }

        /// <summary>
        /// True if total exceeds limit.
        /// </summary>
        public bool HasMore { get; set; }

        /// <summary>
        /// IDs of referencing entities (up to limit).
        /// </summary>
        public IList<string> Ids { get; set; } = [];

        /// <summary>
        /// Maximum IDs returned.
        /// </summary>
        public int Limit { get; set; }

        /// <summary>
        /// Total count of references.
        /// </summary>
        public int Total { get; set; }
    }
}
