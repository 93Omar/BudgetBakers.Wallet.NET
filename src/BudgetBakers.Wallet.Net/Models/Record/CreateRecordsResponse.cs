using BudgetBakers.Wallet.Net.Models.ResponseInfo;

namespace BudgetBakers.Wallet.Net.Models.Record
{
    public class CreateRecordsResponse : IRateLimitResponse
    {
        public IList<CreateRecordResult> Results { get; set; } = [];
        public BatchOperationSummary Summary { get; set; } = new();
        public RateLimitInfo RateLimit { get; set; } = new RateLimitInfo();
    }
}
