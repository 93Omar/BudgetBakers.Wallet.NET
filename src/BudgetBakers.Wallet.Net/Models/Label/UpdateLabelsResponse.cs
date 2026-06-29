using BudgetBakers.Wallet.Net.Models.ResponseInfo;

namespace BudgetBakers.Wallet.Net.Models.Label
{
    public class UpdateLabelsResponse : IRateLimitResponse
    {
        public IList<UpdateLabelResult> Results { get; set; } = [];
        public BatchOperationSummary Summary { get; set; } = new();
        public IList<AgentHint> AgentHints { get; set; } = [];
        public RateLimitInfo RateLimit { get; set; } = new RateLimitInfo();
    }
}
