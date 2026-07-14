using BudgetBakers.Wallet.Net.Models.ResponseInfo;

namespace BudgetBakers.Wallet.Net.Models.Label
{
    public class CreateLabelResponse : IRateLimitResponse
    {
        public RateLimitInfo RateLimit { get; set; } = new RateLimitInfo();
        public Label? Label { get; set; }
        public IList<AgentHint> AgentHints { get; set; } = [];
    }
}
