using BudgetBakers.Wallet.Net.Models.ResponseInfo;

namespace BudgetBakers.Wallet.Net.Models.Delete
{
    public class DeleteEntitiesResponse : IRateLimitResponse
    {
        public IList<DeleteResult> Results { get; set; } = [];
        public BatchOperationSummary Summary { get; set; } = new();
        public RateLimitInfo RateLimit { get; set; } = new RateLimitInfo();
    }
}
