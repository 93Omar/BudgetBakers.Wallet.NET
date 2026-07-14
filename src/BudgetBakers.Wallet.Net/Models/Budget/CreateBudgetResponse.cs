using BudgetBakers.Wallet.Net.Models.ResponseInfo;

namespace BudgetBakers.Wallet.Net.Models.Budget
{
    public class CreateBudgetResponse : IRateLimitResponse
    {
        public RateLimitInfo RateLimit { get; set; } = new RateLimitInfo();
        public Budget? Budget { get; set; }
        public IList<AgentHint> AgentHints { get; set; } = [];
    }
}
