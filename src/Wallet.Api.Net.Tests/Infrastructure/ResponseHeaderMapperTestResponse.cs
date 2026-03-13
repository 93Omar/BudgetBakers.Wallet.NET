using Wallet.Api.Net.Models.ResponseInfo;

namespace Wallet.Api.Net.Tests.Infrastructure
{
    internal sealed class ResponseHeaderMapperTestResponse : IRateLimitResponse, IDataSynchronizationResponse
    {
        public RateLimitInfo RateLimit { get; } = new RateLimitInfo();
        public DataSynchronizationInfo DataSynchronization { get; } = new DataSynchronizationInfo();
    }
}
