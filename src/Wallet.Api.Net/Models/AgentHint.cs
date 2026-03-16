namespace Wallet.Api.Net.Models
{
    /// <summary>
    /// Structured hint for AI agents to understand API responses and take appropriate actions.
    /// </summary>
    public class AgentHint
    {
        /// <summary>
        /// Action data for instruction hints. Only present when severity=instruction. Contains url for fetching next page.
        /// </summary>
        public AgentAction? Action { get; set; }

        /// <summary>
        /// Context data specific to the hint type. Structure varies based on the 'type' field. See 'text' for human-readable explanation.
        /// </summary>
        public object? Data { get; set; }

        /// <summary>
        /// Indicates the nature/importance of the hint.
        /// </summary>
        public AgentHintSeverity Severity { get; set; }

        /// <summary>
        /// Human/AI-readable description of the hint.
        /// </summary>
        public string Text { get; set; } = null!;

        /// <summary>
        /// Hint category using dot-notation.
        /// </summary>
        public AgentHintType Type { get; set; }
    }
}
