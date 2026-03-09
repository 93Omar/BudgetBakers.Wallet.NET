namespace Wallet.Api.Net.Models
{
    public class AgentHint
    {
        public AgentAction? Action { get; set; }
        public object? Data { get; set; }
        public string? Severity { get; set; }
        public string? Text { get; set; }
        public string? Type { get; set; }
    }
}
