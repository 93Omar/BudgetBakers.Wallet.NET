namespace BudgetBakers.Wallet.Net.Models.References
{
    /// <summary>
    /// Cross-reference results for a single entity ID.
    /// </summary>
    public class EntityReferences
    {
        public ReferenceResult? Budgets { get; set; }
        public ReferenceResult? RecordRules { get; set; }
        public ReferenceResult? Records { get; set; }
        public ReferenceResult? StandingOrders { get; set; }

        /// <summary>
        /// Set when the ID could not be resolved: "not found" or "type_mismatch".
        /// </summary>
        public string? Error { get; set; }

        /// <summary>
        /// Human-readable explanation (present on type_mismatch).
        /// </summary>
        public string? Message { get; set; }

        /// <summary>
        /// On type_mismatch, the actual entity type for the ID.
        /// </summary>
        public string? ActualType { get; set; }
    }
}
