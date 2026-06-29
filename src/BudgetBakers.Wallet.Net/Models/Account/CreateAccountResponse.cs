using BudgetBakers.Wallet.Net.Models.ResponseInfo;

namespace BudgetBakers.Wallet.Net.Models.Account
{
    public class CreateAccountResponse : IRateLimitResponse
    {
        public RateLimitInfo RateLimit { get; set; } = new RateLimitInfo();
        public Account? Account { get; set; }
        public IList<AgentHint> AgentHints { get; set; } = [];
    }
}
