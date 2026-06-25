using BudgetBakers.Wallet.Net.Models.ResponseInfo;

namespace BudgetBakers.Wallet.Net.Tests.Infrastructure
{
    internal sealed class ResponseHeaderMapperTestResponse : IRateLimitResponse, IDataSynchronizationResponse
    {
        public RateLimitInfo RateLimit { get; } = new RateLimitInfo();
        public DataSynchronizationInfo DataSynchronization { get; } = new DataSynchronizationInfo();
    }
}
